using PokemonGeneration1.Source.Moves;
using PokemonGeneration1.Source.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Battles
{
    public class BattlePokemonEventArgs : EventArgs
    {
        public Pokemon pokemon;
        public BattlePokemon battlePokemon;
    }

    public class GainedExpEventArgs : BattlePokemonEventArgs
    {
        public float gainedExp;
    }


    public class GainedHPEventArgs : BattlePokemonEventArgs
    {
        public float gainedHP;
    }

    public class MoveEventArgs : BattlePokemonEventArgs
    {
        public Move move;
    }

    public class StatStageChangedEventArgs : BattlePokemonEventArgs
    {
        public StatType statChanged;
        public int change;
    }

    public class SwitchedOutEventArgs : BattlePokemonEventArgs
    {
        public Pokemon switchIn;
    }

    public class MimicMoveEventArgs : BattlePokemonEventArgs
    {
        public BattlePokemon opponent;
        public Move moveMimiced;
    }

    public class TransformedEventArgs : BattlePokemonEventArgs
    {
        public BattlePokemon transformInto;
    }

}
