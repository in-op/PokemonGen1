using PokemonGeneration1.Source.Battles;
using PokemonGeneration1.Source.Moves;
using PokemonGeneration1.Source.PokemonData;
using System;
using System.Collections.Generic;

namespace PokemonStadiumConsoleApp
{
    public static class Display
    {
        public static void Pokemon(BattlePokemon myPokemon, BattlePokemon opponentPokemon, string myName, string opponentName)
        {
            //opponent
            Console.WriteLine();
            Console.WriteLine(opponentName);
            Console.WriteLine(opponentPokemon.Name);
            Console.WriteLine(opponentPokemon.Level + " " + StatusToString(opponentPokemon.Status));
            Console.WriteLine("HP: " + opponentPokemon.HP + "/" + opponentPokemon.MaxHP);
            Console.WriteLine();

            //player
            Console.WriteLine(RightJustify(myPokemon.Name, 32));
            Console.WriteLine(RightJustify(StatusToString(myPokemon.Status) + " " + myPokemon.Level, 32));
            Console.WriteLine(RightJustify("HP: " + myPokemon.HP + "/" + myPokemon.MaxHP, 32));
            Console.WriteLine(RightJustify(myName, 32));
            Console.WriteLine();
        }
        private static string StatusToString(Status status)
        {
            switch (status)
            {
                case Status.BadlyPoisoned:
                    return "PSN";
                case Status.Burn:
                    return "BRN";
                case Status.Fainted:
                    return "FNT";
                case Status.Freeze:
                    return "FRZ";
                case Status.Paralysis:
                    return "PAR";
                case Status.Poison:
                    return "PSN";
                case Status.Sleep:
                    return "SLP";
                default:
                    return "";
            }
        }
        public static string RightJustify(string original, int charsPerLine)
        {
            for (int i = original.Length; i < charsPerLine + 1; i++)
            {
                original = " " + original;
            }
            return original;
        }
        public static string LeftJustify(string original, int charsPerLine)
        {
            for (int i = original.Length; i < charsPerLine + 1; i++)
            {
                original = original + " ";
            }
            return original;
        }

        public static void MainPrompt()
        {
            Console.WriteLine();
            Console.Write("(1) FIGHT");
            Console.WriteLine("  (2) ITEM");
            Console.Write("(3) PKMN");
            Console.WriteLine("   (4) RUN");
            Console.Write("Type number and press enter: ");
        }

        public static void MovePrompt(Side actorSide)
        {
            Console.WriteLine();

            Move move1 = actorSide.CurrentBattlePokemon.Move1;
            Move move2 = actorSide.CurrentBattlePokemon.Move2;
            Move move3 = actorSide.CurrentBattlePokemon.Move3;
            Move move4 = actorSide.CurrentBattlePokemon.Move4;

            Console.WriteLine("(1) " + move1.Name + " " + move1.CurrentPP + "/" + move1.MaxPP);
            if (move2 != null)
            {
                Console.WriteLine("(2) " + move2.Name + " " + move2.CurrentPP + "/" + move2.MaxPP);
            }
            if (move3 != null)
            {
                Console.WriteLine("(3) " + move3.Name + " " + move3.CurrentPP + "/" + move3.MaxPP);
            }
            if (move4 != null)
            {
                Console.WriteLine("(4) " + move4.Name + " " + move4.CurrentPP + "/" + move4.MaxPP);
            }
            Console.WriteLine("(0) - - - back - - -");
            Console.Write("Type number and press enter: ");
        }

        public static void PokemonPrompt(Side actorSide)
        {
            Console.WriteLine();

            List<Pokemon> party = actorSide.Party;

            Console.WriteLine("Select Pokemon:");
            Console.WriteLine("------------------");
            for (int i = 0; i < party.Count; i++)
                Console.WriteLine((i + 1) + " " + party[i].Nickname + " " + StatusToString(party[i].Status));
            Console.WriteLine();
            Console.Write("Type number and press enter");
        }
    }
}
