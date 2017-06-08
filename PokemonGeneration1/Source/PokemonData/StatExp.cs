using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.PokemonData
{
    public sealed class StatExp
    {
        public float HP;
        public float Attack;
        public float Defense;
        public float Special;
        public float Speed;

        public StatExp()
        {
            this.HP = 0;
            this.Attack = 0;
            this.Defense = 0;
            this.Special = 0;
            this.Speed = 0;
        }

        public StatExp(float hp, float attack, float defense, float special, float speed)
        {
            this.HP = hp;
            this.Attack = attack;
            this.Defense = defense;
            this.Special = special;
            this.Speed = speed;
        }
    }
}
