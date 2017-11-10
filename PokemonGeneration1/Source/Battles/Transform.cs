using System;
using PokemonGeneration1.Source.Moves;
using PokemonGeneration1.Source.PokemonData;
using MonteCarloPlayer;

namespace PokemonGeneration1.Source.Battles
{
    public sealed class Transform : Copyable<Transform>
    {
        public bool Active { get; private set; }

        public Type Type1 { get; private set; }
        public Type Type2 { get; private set; }

        private Stats Stats;
        public float Attack  => Stats.Attack;
        public float Defense => Stats.Defense;
        public float Special => Stats.Special;
        public float Speed => Stats.Speed;

        public Move Move1 { get; private set; }
        public Move Move2 { get; private set; }
        public Move Move3 { get; private set; }
        public Move Move4 { get; private set; }



        public void Deactivate() { Active = false; }

        public void Activate(BattlePokemon pokemonToTransformInto)
        {
            Active = true;

            Type1 = pokemonToTransformInto.Type1;
            Type2 = pokemonToTransformInto.Type2;

            Stats = new Stats(
                0f,
                pokemonToTransformInto.PokemonsAttackStat,
                pokemonToTransformInto.PokemonsDefenseStat,
                pokemonToTransformInto.PokemonsSpecialStat,
                pokemonToTransformInto.PokemonsSpeedStat);

            Move1 = MoveFactory.Create(pokemonToTransformInto.Move1.Index);
            Move2 = MoveFactory.Create(pokemonToTransformInto.Move2.Index);
            Move3 = MoveFactory.Create(pokemonToTransformInto.Move3.Index);
            Move4 = MoveFactory.Create(pokemonToTransformInto.Move4.Index);

            Move1.CurrentPP = 5;
            Move2.CurrentPP = 5;
            Move3.CurrentPP = 5;
            Move4.CurrentPP = 5;
        }



        public Transform DeepCopy()
        {
            if (Active)
                return new Transform(
                    Active,
                    Type1, Type2,
                    Stats,
                    Move1.DeepCopy(), Move2.DeepCopy(), Move3.DeepCopy(), Move4.DeepCopy());
            else return new Transform();
        }

        public void CopyTo(Transform other)
        {
            other.Active = Active;
            if (Active)
            {
                other.Type1 = Type1;
                other.Type2 = Type2;
                other.Stats = Stats;
                Move1.CopyTo(other.Move1);
                Move2.CopyTo(other.Move2);
                Move3.CopyTo(other.Move3);
                Move4.CopyTo(other.Move4);
            }
        }



        public Transform() { }

        private Transform(
            bool active,
            Type type1, Type type2,
            Stats stats,
            Move move1, Move move2, Move move3, Move move4)
        {
            Active = active;
            Type1 = type1;
            Type2 = type2;
            Stats = stats;
            Move1 = move1;
            Move2 = move2;
            Move3 = move3;
            Move4 = move4;
        }


    }
}
