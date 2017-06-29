using PokemonGeneration1.Source.Battles;
using PokemonGeneration1.Source.Moves;
using PokemonGeneration1.Source.PokemonData;
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
                        battle.OpponentSide.CurrentBattlePokemon,
                        actorSide.Name,
                        battle.OpponentSide.Name);
                    Display.MainPrompt();
                    string mainChoice = Console.ReadLine();
                    if (mainChoice == "1")
                    {
                        if (actorSide.CurrentBattlePokemon.IsMultiTurnMoveActive())
                        {
                            selection = Selection.MakeContinueMultiTurnMove(
                                actorSide.CurrentBattlePokemon,
                                battle.OpponentSide.CurrentBattlePokemon);
                            return;
                        }
                        else if (actorSide.CurrentBattlePokemon.PartiallyTrapped)
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
                    var opponentPoke = battle.OpponentSide.CurrentBattlePokemon;
                    Display.Pokemon(
                        myPoke,
                        opponentPoke,
                        actorSide.Name,
                        battle.OpponentSide.Name);
                    Display.MovePrompt(actorSide);
                    string moveChoice = Console.ReadLine();

                    if (moveChoice == "0")
                    {
                        state = MainMenuState.MAIN;
                    }
                    else if (moveChoice == "1")
                    {
                        selection = Selection.MakeFight(
                            myPoke, opponentPoke, myPoke.Move1);
                    }
                    else if (moveChoice == "2")
                    {
                        selection = Selection.MakeFight(
                            myPoke, opponentPoke, myPoke.Move2);
                    }
                    else if (moveChoice == "3")
                    {
                        selection = Selection.MakeFight(
                            myPoke, opponentPoke, myPoke.Move3);
                    }
                    else if (moveChoice == "4")
                    {
                        selection = Selection.MakeFight(
                            myPoke, opponentPoke, myPoke.Move4);
                    }
                    break;

                case MainMenuState.ITEM:
                    break;

                case MainMenuState.POKEMONFORITEM:
                    break;

                case MainMenuState.POKEMONFORSWITCH:
                    selection = SwitchPokemonPrompt(battle, actorSide);
                    break;
            }
        }

        public Selection MakeForcedSwitchSelection(Battle battle, Side actorSide)
        {
            return SwitchPokemonPrompt(battle, actorSide);
        }

        public Move PickMoveToMimic(Side opponentSide)
        {
            throw new NotImplementedException();
        }








        private static Selection SwitchPokemonPrompt(Battle battle, Side actorSide)
        {
            Selection selection;
            Console.Clear();
            Display.PokemonPrompt(actorSide);

            int pokemonPick;
            while (!int.TryParse(Console.ReadLine(), out pokemonPick)
                  || pokemonPick < 1
                  || pokemonPick > actorSide.Party.Count
                  || actorSide.Party[pokemonPick - 1].Status == Status.Fainted
                  || actorSide.Party[pokemonPick - 1] == actorSide.CurrentBattlePokemon.Pokemon)
            {
                Console.Clear();
                Display.PokemonPrompt(actorSide);
            }

            selection = Selection.MakeSwitchOut(
                actorSide.CurrentBattlePokemon,
                battle.OpponentSide.CurrentBattlePokemon,
                actorSide.Party[pokemonPick - 1]);

            Console.Clear();
            Display.Pokemon(
                actorSide.CurrentBattlePokemon,
                battle.OpponentSide.CurrentBattlePokemon,
                actorSide.Name,
                battle.OpponentSide.Name);

            return selection;
        }
    }
}
