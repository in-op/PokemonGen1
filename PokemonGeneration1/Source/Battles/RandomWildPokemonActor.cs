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
            if (actorSide.CurrentBattlePokemon.IsMultiTurnMoveActive())
            {
                return Selection.MakeContinueMultiTurnMove(actorSide.CurrentBattlePokemon,
                                                           battle.GetPlayerSide().CurrentBattlePokemon);
            }
            else if (actorSide.CurrentBattlePokemon.IsPartiallyTrapped())
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
            return Selection.MakeFight(actorSide.CurrentBattlePokemon,
                                       battle.GetPlayerSide().CurrentBattlePokemon,
                                       PickRandomMove(actorSide));
        }
        private Move PickRandomMove(Side actorSide)
        {
            var poke = actorSide.CurrentBattlePokemon;
            var rng = new Random();
            Move move = null;
            while (move == null)
            {
                int rando = rng.Next(1, 5);
                if (rando == 1 &&
                    poke.Move1 != null)
                {
                    move = poke.Move1;
                }
                else if (rando == 2 &&
                         poke.Move2 != null)
                {
                    move = poke.Move2;
                }
                else if (rando == 3 &&
                         poke.Move3 != null)
                {
                    move = poke.Move3;
                }
                else if (rando == 4 &&
                         poke.Move4 != null)
                {
                    move = poke.Move4;
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
