using PokemonGeneration1.Source.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Moves
{
    public abstract class AttackMove : TransitiveMove
    {
        public readonly float Power;
        protected readonly bool IsHighCritRatioMove;
        protected bool CritFlag;
        protected float EffectivenessMultiplier;


        protected void UpdateEffectivenessUpdateCritFlagAndDoDamage(BattlePokemon user, BattlePokemon defender)
        {
            this.UpdateEffectiveness(defender);
            this.UpdateCritFlag(user);
            float damageAmount = calculateDamage(user, defender);
            defender.Damage(damageAmount, this.Type);
        }

        //Effectiveness & Crit must be updated immediately before calculateDamage()
        protected void UpdateEffectiveness(BattlePokemon defender)
        {
            float effectivenessMultiplier = GetTypeMatchupMultiplier(defender);
            this.EffectivenessMultiplier = effectivenessMultiplier;

            if (this.EffectivenessMultiplier > 1f)
            {
                OnSuperEffective();
            }
            else if (this.EffectivenessMultiplier < 1f)
            {
                OnNotVeryEffective();
            }
        }
        protected void UpdateCritFlag(BattlePokemon user)
        {
            int t = (int)Math.Floor(user.GetBaseSpeed() / 2);
            if (user.IsFocusEnergyActive() ||
                user.IsDireHitActive())
            {
                t /= 4;
            }
            if (this.IsHighCritRatioMove)
            {
                t *= 8;
            }
            if (t > 255) { t = 255; }
            if (new Random().Next(0, 256) < t)
            {
                this.CritFlag = true;
                OnCriticalHit();
            }
            else this.CritFlag = false;
        }
        protected float calculateDamage(BattlePokemon user, BattlePokemon defender)
        {
            float relativeLevel;
            if (this.CritFlag == true)
            {
                relativeLevel = user.GetLevel() * 2f;
            }
            else
            {
                relativeLevel = user.GetLevel();
            }

            //checks for light screen
            float relativeDefenderSpecial = defender.GetSpecial();
            if (defender.IsLightScreenActive() &&
                CritFlag == false)
            {
                relativeDefenderSpecial *= 2f;
                if (relativeDefenderSpecial > 1024f) { relativeDefenderSpecial = 1024f; }
            }
            //checks for reflect
            float relativeDefenderDefense = defender.GetDefense();
            if (defender.IsReflectActive() &&
                CritFlag == false)
            {
                relativeDefenderDefense *= 2f;
                if (relativeDefenderDefense > 1024f) { relativeDefenderDefense = 1024f; }
            }

            //if crit on transformed pokemon, defender uses original stats in damage calculation
            if (defender.IsTransformActive() && this.CritFlag == true)
            {
                if (this.Category == Category.PHYSICAL)
                {
                    return damageFormula(relativeLevel,
                                         user.GetAttack(),
                                         defender.GetPokemonsDefenseStatWithModifiers(),
                                         this.Power,
                                         getStab(user),
                                         this.EffectivenessMultiplier);
                }
                else return damageFormula(relativeLevel,
                                          user.GetSpecial(),
                                          defender.GetPokemonsSpecialStatWithModifiers(),
                                          this.Power,
                                          getStab(user),
                                          this.EffectivenessMultiplier);
            }

            else if (this.Category == Category.PHYSICAL)
            {
                return damageFormula(relativeLevel,
                                       user.GetAttack(),
                                       relativeDefenderDefense,
                                       this.Power,
                                       getStab(user),
                                       this.EffectivenessMultiplier);
            }
            else return damageFormula(relativeLevel,
                                      user.GetSpecial(),
                                      relativeDefenderSpecial,
                                      this.Power,
                                      getStab(user),
                                      this.EffectivenessMultiplier);
        }
        public static float damageFormula(float attackerLevel,
                                           float attackStat,
                                           float defenseStat,
                                           float power,
                                           float stab,
                                           float typeModifier)
        {
            return (float)Math.Floor(((((((2f * attackerLevel / 5f) + 2f) * attackStat * power / defenseStat / 50f) + 2f) * stab * typeModifier * (float)new Random().Next(217, 256)) / 255f));
        }
        private float getStab(BattlePokemon attackPokemon)
        {
            float stab;
            if (attackPokemon.GetType1() == this.Type ||
                attackPokemon.GetType2() == this.Type)
            {
                stab = 1.5f;
            }
            else stab = 1f;
            return stab;
        }



        protected AttackMove(int index, string name, Type type, int startingPP, int absoluteMaxPP, float accuracyPercent, float power, int priority, bool isHighCritRatio, Category category)
            : base(index, name, type, startingPP, absoluteMaxPP, accuracyPercent, priority, category)
        {
            this.Power = power;
            this.CritFlag = false;
        }
    }
}
