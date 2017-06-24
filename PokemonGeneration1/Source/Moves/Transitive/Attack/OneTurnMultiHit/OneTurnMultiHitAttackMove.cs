using System;
using PokemonGeneration1.Source.Battles;
using PokemonGeneration1.Source.PokemonData;

namespace PokemonGeneration1.Source.Moves.Transitive.Attack.OneTurnMultiHit
{
    public abstract class OneTurnMultiHitAttackMove : AttackMove
    {
        protected int numberOfHits;

        protected void ExecuteMultiHitDamage(BattlePokemon defender, float amount)
        {
            //only the first damage will execute with side effects, e.g. updating Bide
            defender.Damage(amount, this.Type);
            for (int i = 1; i < numberOfHits; i++)
            {
                if (defender.DidSubstituteBreakThisTurn() ||
                    defender.Status == PokemonData.Status.FAINTED)
                {
                    break;
                }
                defender.DamageWithoutBideOrCounterSideEffects(amount);
            }
        }

        protected void ExecuteMultiHitDamageAndAttemptPoison(BattlePokemon defender, float amount)
        {
            //only the first damage will execute with side effects, e.g. updating Bide
            defender.Damage(amount, this.Type);

            bool canPoison = defender.GetType1() != Type.Poison &&
                             defender.GetType2() != Type.Poison &&
                             defender.Status != PokemonData.Status.POISON &&
                             defender.Status != PokemonData.Status.BADLYPOISONED;

            //attempt poison
            if (canPoison &&
                new Random().Next(0, 100) < 20)
            {
                defender.PoisonAsSecondaryEffect();
            }


            for (int i = 1; i < numberOfHits; i++)
            {
                if (defender.DidSubstituteBreakThisTurn() ||
                    defender.Status == PokemonData.Status.FAINTED)
                {
                    break;
                }
                defender.DamageWithoutBideOrCounterSideEffects(amount);

                //attempt poison
                if (canPoison &&
                    new Random().Next(0, 100) < 20)
                {
                    defender.PoisonAsSecondaryEffect();
                }
            }
        }

        protected void SetRandomNumberOfHits()
        {
            int rando = new Random().Next(0, 1000);
            if (rando < 375) { this.numberOfHits = 2; }
            else if (rando < 750) { this.numberOfHits = 3; }
            else if (rando < 875) { this.numberOfHits = 4; }
            else this.numberOfHits = 5;
        }

        protected OneTurnMultiHitAttackMove(int index, string name, Type type, int startingPP, int absoluteMaxPP, float accuracyPercent, float power, Category category)
            : base(index, name, type, startingPP, absoluteMaxPP, accuracyPercent, power, 0, false, category)
        {
            this.numberOfHits = 0;
        }
    }
}
