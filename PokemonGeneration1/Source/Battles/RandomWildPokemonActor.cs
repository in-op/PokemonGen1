using PokemonGeneration1.Source.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Battles
{
    public class RandomWildPokemonActor : BattleActor
    {
        public Selection MakeBeginningOfTurnSelection(Battle battle, Side actorSide)
        {
            if (actorSide.GetCurrentBattlePokemon().IsMultiTurnMoveActive())
            {
                return Selection.MakeContinueMultiTurnMove(actorSide.GetCurrentBattlePokemon(),
                                                           battle.GetPlayerSide().GetCurrentBattlePokemon());
            }
            else if (actorSide.GetCurrentBattlePokemon().IsPartiallyTrapped())
            {
                return Selection.MakeEmptyFight();
            }
            else
            {
                return MakeRandomFightSelection(battle, actorSide);
            }
        }
        private Selection MakeRandomFightSelection(Battle battle, Side actorSide)
        {
            return Selection.MakeFight(actorSide.GetCurrentBattlePokemon(),
                                       battle.GetPlayerSide().GetCurrentBattlePokemon(),
                                       PickRandomMove(actorSide));
        }
        private Move PickRandomMove(Side actorSide)
        {
            var poke = actorSide.GetCurrentBattlePokemon();
            var rng = new Random();
            Move move = null;
            while (move == null)
            {
                int rando = rng.Next(1, 5);
                if (rando == 1 &&
                    poke.GetMove1() != null)
                {
                    move = poke.GetMove1();
                }
                else if (rando == 2 &&
                         poke.GetMove2() != null)
                {
                    move = poke.GetMove2();
                }
                else if (rando == 3 &&
                         poke.GetMove3() != null)
                {
                    move = poke.GetMove3();
                }
                else if (rando == 4 &&
                         poke.GetMove4() != null)
                {
                    move = poke.GetMove4();
                }
            }
            return move;
        }

        public Selection MakeForcedSwitchSelection(Battle battle, Side actorSide)
        {
            throw new NotImplementedException();
        }

        public Move PickMoveToMimic(Side opponentSide)
        {
            throw new NotImplementedException();
        }
    }
}
