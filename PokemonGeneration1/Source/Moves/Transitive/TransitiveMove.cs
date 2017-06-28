using PokemonGeneration1.Source.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Moves
{
    public abstract class TransitiveMove : Move
    {
        public readonly float AccuracyPercent;


        
        protected void SetLastMoveAndMirrorMove(BattlePokemon user, BattlePokemon defender)
        {
            user.SetLastMoveUsed(this);
            defender.SetMirrorMove(this);
        }



        protected bool IsAMiss(BattlePokemon user, BattlePokemon defender)
        {
            float accuracyPercent = AccuracyPercent *
                                    user.AccuracyMultiplier *
                                    defender.EvasionMultiplier;
            if (defender.IsSemiInvulnerable())
            {
                return true;
            }
            if (new Random().Next(0, 100) < accuracyPercent)
            {
                return false;
            }

            return true;
        }



        protected bool HasNoEffect(BattlePokemon defender)
        {
            return GetTypeMatchupMultiplier(defender) == 0f;
        }



        protected float GetTypeMatchupMultiplier(BattlePokemon defender)
        {
            return TypeEffectiveness(Type, defender.Type1) *
                   TypeEffectiveness(Type, defender.Type2);
        }
        private static float TypeEffectiveness(Type attackType, Type defenseType)
        {
            return typeEffectiveness[(int)attackType][(int)defenseType];
        }

        private static readonly float[][] typeEffectiveness = new float[][]
        {
            // [attackType][defenseType]
            //NONE
            new float[] {1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f },
            //NORMAL
            new float[] {1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.5f, 0.0f, 1.0f },
            //FIRE
            new float[] {1.0f, 1.0f, 0.5f, 0.5f, 1.0f, 2.0f, 2.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 2.0f, 0.5f, 1.0f, 0.5f },
            //WATER
            new float[] {1.0f, 1.0f, 2.0f, 0.5f, 1.0f, 0.5f, 1.0f, 1.0f, 1.0f, 2.0f, 1.0f, 1.0f, 1.0f, 2.0f, 1.0f, 0.5f },
            //ELECTRIC
            new float[] {1.0f, 1.0f, 1.0f, 2.0f, 0.5f, 0.5f, 1.0f, 1.0f, 1.0f, 0.0f, 2.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.5f },
            //GRASS
            new float[] {1.0f, 1.0f, 0.5f, 2.0f, 1.0f, 0.5f, 1.0f, 1.0f, 0.5f, 2.0f, 0.5f, 1.0f, 0.5f, 2.0f, 1.0f, 0.5f },
            //ICE
            new float[] {1.0f, 1.0f, 1.0f, 0.5f, 1.0f, 2.0f, 0.5f, 1.0f, 1.0f, 2.0f, 2.0f, 1.0f, 1.0f, 1.0f, 1.0f, 2.0f },
            //FIGHTING
            new float[] {1.0f, 2.0f, 1.0f, 1.0f, 1.0f, 1.0f, 2.0f, 1.0f, 0.5f, 1.0f, 0.5f, 0.5f, 0.5f, 2.0f, 0.0f, 1.0f },
            //POISON
            new float[] {1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 2.0f, 1.0f, 1.0f, 0.5f, 0.5f, 1.0f, 1.0f, 2.0f, 0.5f, 0.5f, 1.0f },
            //GROUND
            new float[] {1.0f, 1.0f, 2.0f, 1.0f, 2.0f, 0.5f, 1.0f, 1.0f, 2.0f, 1.0f, 0.0f, 1.0f, 0.5f, 2.0f, 1.0f, 1.0f },
            //FLYING
            new float[] {1.0f, 1.0f, 1.0f, 1.0f, 0.5f, 2.0f, 1.0f, 2.0f, 1.0f, 1.0f, 1.0f, 1.0f, 2.0f, 0.5f, 1.0f, 1.0f },
            //PSYCHIC
            new float[] {1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 2.0f, 2.0f, 1.0f, 1.0f, 0.5f, 1.0f, 1.0f, 1.0f, 1.0f },
            //BUG
            new float[] {1.0f, 1.0f, 0.5f, 1.0f, 1.0f, 2.0f, 1.0f, 0.5f, 2.0f, 1.0f, 0.5f, 2.0f, 1.0f, 1.0f, 1.0f, 1.0f },
            //ROCK
            new float[] {1.0f, 1.0f, 2.0f, 1.0f, 1.0f, 1.0f, 2.0f, 0.5f, 1.0f, 0.5f, 2.0f, 1.0f, 2.0f, 1.0f, 1.0f, 1.0f },
            //GHOST
            new float[] {1.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.0f, 1.0f, 1.0f, 2.0f, 1.0f },
            //DRAGON
            new float[] {1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 2.0f }
        };



        protected TransitiveMove(int index, string name, Type type, int startingPP, int absoluteMaxPP, float accuracyPercent, int priority, Category category)
            : base(index, name, type, startingPP, absoluteMaxPP, priority, category)
        {
            AccuracyPercent = accuracyPercent;
        }
    }
}
