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
        public float Attack { get => Stats.Attack; }
        public float Defense { get => Stats.Defense; }
        public float Special { get => Stats.Special; }
        public float Speed { get => Stats.Speed; }

        public Move Move1 { get; private set; }
        public Move Move2 { get; private set; }
        public Move Move3 { get; private set; }
        public Move Move4 { get; private set; }
        


        public void Deactivate()
        {
            Active = false;
        }

        public void Activate(BattlePokemon pokemonToTransformInto)
        {
            Active = true;

            Type1 = pokemonToTransformInto.GetType1();
            Type2 = pokemonToTransformInto.GetType2();

            Stats = new Stats(
                0f,
                pokemonToTransformInto.GetPokemonsAttackStat(),
                pokemonToTransformInto.GetPokemonsDefenseStat(),
                pokemonToTransformInto.GetPokemonsSpecialStat(),
                pokemonToTransformInto.GetPokemonsSpeedStat());

            Move1 = MoveFactory.Create(pokemonToTransformInto.GetMove1().Index);
            Move2 = MoveFactory.Create(pokemonToTransformInto.GetMove2().Index);
            Move3 = MoveFactory.Create(pokemonToTransformInto.GetMove3().Index);
            Move4 = MoveFactory.Create(pokemonToTransformInto.GetMove4().Index);

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
