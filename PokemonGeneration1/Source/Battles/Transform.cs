using PokemonGeneration1.Source.Moves;
using PokemonGeneration1.Source.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Battles
{
    public sealed class Transform
    {
        private bool Active;
        private Type Type1;
        private Type Type2;
        private Stats Stats;
        private Move Move1;
        private Move Move2;
        private Move Move3;
        private Move Move4;

        public bool IsActive() { return Active; }
        public Type GetType1() { return Type1; }
        public Type GetType2() { return Type2; }
        public float GetAttack() { return Stats.Attack; }
        public float GetDefense() { return Stats.Defense; }
        public float GetSpecial() { return Stats.Special; }
        public float GetSpeed() { return Stats.Speed; }
        public Move GetMove1() { return Move1; }
        public Move GetMove2() { return Move2; }
        public Move GetMove3() { return Move3; }
        public Move GetMove4() { return Move4; }
        



        public Transform()
        {
            Active = false;
        }

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
            Move1 = MoveFactory.CreateMove(pokemonToTransformInto.GetMove1().Index);
            Move2 = MoveFactory.CreateMove(pokemonToTransformInto.GetMove2().Index);
            Move3 = MoveFactory.CreateMove(pokemonToTransformInto.GetMove3().Index);
            Move4 = MoveFactory.CreateMove(pokemonToTransformInto.GetMove4().Index);
            while (Move1.GetCurrentPP() > 5)
            {
                Move1.SubtractPP(1);
            }
            while (Move2.GetCurrentPP() > 5)
            {
                Move2.SubtractPP(1);
            }
            while (Move3.GetCurrentPP() > 5)
            {
                Move3.SubtractPP(1);
            }
            while (Move4.GetCurrentPP() > 5)
            {
                Move4.SubtractPP(1);
            }
        }
    }
}
