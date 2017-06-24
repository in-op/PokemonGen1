using PokemonGeneration1.Source.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Moves.Transitive.Attack.MultiTurn
{
    public abstract class MultiTurnAttackMove : AttackMove
    {
        protected float Damage;
        protected int TurnsLeft;

        public sealed override void Abort()
        {
            TurnsLeft = 0;
        }

        protected void ExecuteBindingMove(BattlePokemon user, BattlePokemon defender)
        {
            if (TurnsLeft == 0)
            {
                OnUsed();

                if (IsAMiss(user, defender)) OnMissed();
                else
                {
                    if (HasNoEffect(defender)) OnNoEffect();
                    else
                    {
                        UpdateEffectiveness(defender);
                        UpdateCritFlag(user);
                        Damage = calculateDamage(user, defender);
                        defender.Damage(Damage, Type);
                    }
                    SetTurnsLeftForBindingMoves();
                    user.ActivateMultiTurnMove(this);
                    defender.ActivatePartialTrapping();
                }

                user.SetLastMoveUsed(this);
                SubtractPP(1);
            }
            else
                if (defender.DidPokemonSwitchThisTurn())
                {
                    TurnsLeft = 0;
                    ExecuteAndUpdate(user, defender);
                }
                else
                {
                    OnAttackContinues();
                    if (HasNoEffect(defender)) OnNoEffect();
                    else defender.Damage(Damage, Type);

                    --TurnsLeft;
                    if (TurnsLeft == 0)
                    {
                        user.DeactivateMultiTurnMove();
                        defender.DeactivatePartialTrappingAtEndOfTurn();
                    }
                }
        }

        private void SetTurnsLeftForBindingMoves()
        {
            int rando = new Random().Next(0, 1000);
            if (rando < 375)
            {
                TurnsLeft = 2;
            }
            else if (rando < 750)
            {
                TurnsLeft = 3;
            }
            else if (rando < 875)
            {
                TurnsLeft = 4;
            }
            else
            {
                TurnsLeft = 5;
            }
        }

        protected MultiTurnAttackMove(int index, string name, Type type, int startingPP, int absoluteMaxPP, float accuracyPercent, float power, Category category)
            : base(index, name, type, startingPP, absoluteMaxPP, accuracyPercent, power, 0, false, category)
        {
            Damage = 0f;
            TurnsLeft = 0;
        }
    }
}
