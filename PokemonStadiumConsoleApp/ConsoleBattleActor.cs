using PokemonGeneration1.Source.Battles;
using PokemonGeneration1.Source.Moves;
using System;
using System.Threading;

namespace PokemonStadiumConsoleApp
{
    public class ConsoleBattleActor : BattleActor
    {
        public Selection MakeBeginningOfTurnSelection(Battle battle, Side actorSide)
        {
            Selection playersSelection = null;
            MainMenuState currentState = MainMenuState.MAIN;

            while(playersSelection == null)
                Tick(
                    ref playersSelection,
                    ref currentState,
                    battle,
                    actorSide);

            return playersSelection;
        }



        private void Tick(
            ref Selection selection,
            ref MainMenuState state,
            Battle battle,
            Side actorSide)
        {
            switch (state)
            {
                case MainMenuState.MAIN:
                    Console.Clear();
                    Display.Pokemon(
                        actorSide.CurrentBattlePokemon,
                        battle.GetOpponentSide().CurrentBattlePokemon,
                        actorSide.Name,
                        battle.GetOpponentSide().Name);
                    Display.MainPrompt();
                    string mainChoice = Console.ReadLine();
                    if (mainChoice == "1")
                    {
                        if (actorSide.CurrentBattlePokemon.IsMultiTurnMoveActive())
                        {
                            selection = Selection.MakeContinueMultiTurnMove(
                                actorSide.CurrentBattlePokemon,
                                battle.GetOpponentSide().CurrentBattlePokemon);
                            return;
                        }
                        else if (actorSide.CurrentBattlePokemon.IsPartiallyTrapped())
                        {
                            selection = Selection.MakeEmptyFight();
                            return;
                        }
                        state = MainMenuState.MOVE;
                    }
                    else if (mainChoice == "2")
                    {
                        state = MainMenuState.ITEM;
                    }
                    else if (mainChoice == "3")
                    {
                        state = MainMenuState.POKEMONFORSWITCH;
                    }
                    else if (mainChoice == "4")
                    {
                        // 
                    }
                    break;

                case MainMenuState.MOVE:
                    Console.Clear();
                    var myPoke = actorSide.CurrentBattlePokemon;
                    var opponentPoke = battle.GetOpponentSide().CurrentBattlePokemon;
                    Display.Pokemon(
                        myPoke,
                        opponentPoke,
                        actorSide.Name,
                        battle.GetOpponentSide().Name);
                    Display.MovePrompt(actorSide);
                    string moveChoice = Console.ReadLine();

                    if (moveChoice == "0")
                    {
                        state = MainMenuState.MAIN;
                    }
                    else if (moveChoice == "1")
                    {
                        selection = Selection.MakeFight(
                            myPoke, opponentPoke, myPoke.GetMove1());
                    }
                    else if (moveChoice == "2")
                    {
                        selection = Selection.MakeFight(
                            myPoke, opponentPoke, myPoke.GetMove2());
                    }
                    else if (moveChoice == "3")
                    {
                        selection = Selection.MakeFight(
                            myPoke, opponentPoke, myPoke.GetMove3());
                    }
                    else if (moveChoice == "4")
                    {
                        selection = Selection.MakeFight(
                            myPoke, opponentPoke, myPoke.GetMove4());
                    }
                    break;

                case MainMenuState.ITEM:
                    break;

                case MainMenuState.POKEMONFORITEM:
                    break;

                case MainMenuState.POKEMONFORSWITCH:

                    Console.Clear();
                    Display.PokemonPrompt(actorSide);

                    int pokemonPick;
                    while (!int.TryParse(Console.ReadLine(), out pokemonPick)
                          || pokemonPick < 1
                          || pokemonPick > actorSide.Party.Count)
                    {
                        Console.Clear();
                        Display.PokemonPrompt(actorSide);
                    }

                    selection = Selection.MakeSwitchOut(
                        actorSide.CurrentBattlePokemon,
                        battle.GetOpponentSide().CurrentBattlePokemon,
                        actorSide.Party[pokemonPick - 1]);

                    break;
            }
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
