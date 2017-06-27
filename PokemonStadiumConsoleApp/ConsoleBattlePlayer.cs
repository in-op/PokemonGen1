using PokemonGeneration1.Source.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonStadiumConsoleApp
{
    public static class ConsoleBattlePlayer
    {
        public static void Run(Side mySide, Side opponentSide, BattleActor opponentActor)
        {
            Battle battle = new Battle(mySide, opponentSide, new ConsoleBattleActor(), opponentActor);

            BattleEventsHandler.AttachMyBattlePokemonEventHandlers(mySide.CurrentBattlePokemon);
            BattleEventsHandler.AttachOpponentBattlePokemonEventHandlers(opponentSide.CurrentBattlePokemon);
            BattleEventsHandler.AttachBattleEventHandlers(battle);

            battle.Play();
        }
    }
}
