using PokemonGeneration1.Source.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Moves.Transitive.Attack.OneTurnOneHit
{
    public abstract class OneTurnOneHitAttackMove : AttackMove
    {

        protected void UpdateEffectivenessUpdateCritDoDamageAndRestoreHP(BattlePokemon user, BattlePokemon defender)
        {
            UpdateEffectiveness(defender);
            UpdateCritFlag(user);
            float damage = CalcDamage(user, defender);
            float remainingHP = defender.HP;
            defender.Damage(damage, this.Type);
            if (!defender.DidSubstituteBreakThisTurn())
            {
                float sap = (float)Math.Ceiling(Math.Min(damage, remainingHP) / 2f);
                user.RestoreHP(sap);
                OnRegainedHealth();
            }
        }

        protected OneTurnOneHitAttackMove(int index, string name, Type type, int startingPP, int absoluteMaxPP, float accuracyPercent, float power, int priority, bool isHighCritRatio, Battles.Category category)
            : base(index, name, type, startingPP, absoluteMaxPP, accuracyPercent, power, priority, isHighCritRatio, category) { }
    }
}
