using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Battles
{
    public enum BattleState
    {
        Intro,
        SetSelections,
        SetFirstAndSecond,
        FirstExecutes,
        SecondExecutes,
        FirstFaintsEarly,
        FirstFaintsEarlySwitch,
        BothFaint,
        SecondFaints,
        FirstFaintsLate,
        FirstFaintsLateSwitch,
        SecondSwitchesPokemon,
        BothPokemonSwitch,
        GameOver
    }
}
