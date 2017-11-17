using PokemonGeneration1.Source.Moves;
using PokemonGeneration1.Source.PokemonData;

namespace PokemonGeneration1.Source.Battles
{
    public sealed class Transform
    {
        public bool Active { get; private set; }

        public Type Type1 { get; private set; }
        public Type Type2 { get; private set; }

        private Stats Stats;
        public float Attack => Stats.Attack;
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

            while (Move1.CurrentPP > 5)
                Move1.SubtractPP(1);
            while (Move2.CurrentPP > 5)
                Move2.SubtractPP(1);
            while (Move3.CurrentPP > 5)
                Move3.SubtractPP(1);
            while (Move4.CurrentPP > 5)
                Move4.SubtractPP(1);
        }
    }
}
