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
        private Types Type1;
        private Types Type2;
        private Stats Stats;
        private Move Move1;
        private Move Move2;
        private Move Move3;
        private Move Move4;

        public bool IsActive() { return this.Active; }
        public Types GetType1() { return this.Type1; }
        public Types GetType2() { return this.Type2; }
        public float GetAttack() { return this.Stats.Attack; }
        public float GetDefense() { return this.Stats.Defense; }
        public float GetSpecial() { return this.Stats.Special; }
        public float GetSpeed() { return this.Stats.Speed; }
        public Move GetMove1() { return this.Move1; }
        public Move GetMove2() { return this.Move2; }
        public Move GetMove3() { return this.Move3; }
        public Move GetMove4() { return this.Move4; }
        



        public Transform()
        {
            this.Active = false;
        }

        public void Deactivate()
        {
            this.Active = false;
        }

        public void Activate(BattlePokemon pokemonToTransformInto)
        {
            this.Active = true;
            this.Type1 = pokemonToTransformInto.GetType1();
            this.Type2 = pokemonToTransformInto.GetType2();
            this.Stats = new Stats(0f,
                                   pokemonToTransformInto.GetPokemonsAttackStat(),
                                   pokemonToTransformInto.GetPokemonsDefenseStat(),
                                   pokemonToTransformInto.GetPokemonsSpecialStat(),
                                   pokemonToTransformInto.GetPokemonsSpeedStat());
            this.Move1 = MoveFactory.CreateMove(pokemonToTransformInto.GetMove1().GetIndex());
            this.Move2 = MoveFactory.CreateMove(pokemonToTransformInto.GetMove2().GetIndex());
            this.Move3 = MoveFactory.CreateMove(pokemonToTransformInto.GetMove3().GetIndex());
            this.Move4 = MoveFactory.CreateMove(pokemonToTransformInto.GetMove4().GetIndex());
            while (this.Move1.GetCurrentPP() > 5)
            {
                this.Move1.SubtractPP(1);
            }
            while (this.Move2.GetCurrentPP() > 5)
            {
                this.Move2.SubtractPP(1);
            }
            while (this.Move3.GetCurrentPP() > 5)
            {
                this.Move3.SubtractPP(1);
            }
            while (this.Move4.GetCurrentPP() > 5)
            {
                this.Move4.SubtractPP(1);
            }
        }
    }
}
