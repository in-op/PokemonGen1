using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.PokemonData
{
    public class PokemonEventArgs : EventArgs
    {
        public Pokemon pokemon;
    }

    public class GainedExpEventArgs : PokemonEventArgs
    {
        public float exp;

        public GainedExpEventArgs(Pokemon pokemon, float exp)
        {
            this.pokemon = pokemon;
            this.exp = exp;
        }
    }

    public class GainedHPEventArgs : PokemonEventArgs
    {
        public float gainedHP;

        public GainedHPEventArgs(Pokemon thisPokemon, float gainedHP)
        {
            this.pokemon = thisPokemon;
            this.gainedHP = gainedHP;
        }
    }
}
