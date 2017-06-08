using PokemonGeneration1.Source.Battles;
using PokemonGeneration1.Source.Moves;
using PokemonGeneration1.Source.PokemonData;
using System;

namespace PokemonGeneration1.Source.ConsoleUI
{
    public static class Display
    {
        public static void Pokemon(BattlePokemon myPokemon, BattlePokemon opponentPokemon, string myName, string opponentName)
        {
            //opponent
            Console.WriteLine();
            Console.WriteLine(opponentName);
            Console.WriteLine(opponentPokemon.GetName());
            Console.WriteLine(opponentPokemon.GetLevel() + " " + StatusToString(opponentPokemon.Status));
            Console.WriteLine("HP: " + opponentPokemon.HP + "/" + opponentPokemon.GetMaxHP());
            Console.WriteLine();

            //player
            Console.WriteLine(RightJustify(myPokemon.GetName(), 32));
            Console.WriteLine(RightJustify(StatusToString(myPokemon.Status) + " " + myPokemon.GetLevel(), 32));
            Console.WriteLine(RightJustify("HP: " + myPokemon.HP + "/" + myPokemon.GetMaxHP(), 32));
            Console.WriteLine(RightJustify(myName, 32));
            Console.WriteLine();
        }
        private static string StatusToString(Status status)
        {
            switch (status)
            {
                case Status.BADLYPOISONED:
                    return "PSN";
                case Status.BURN:
                    return "BRN";
                case Status.FAINTED:
                    return "FNT";
                case Status.FREEZE:
                    return "FRZ";
                case Status.PARALYSIS:
                    return "PAR";
                case Status.POISON:
                    return "PSN";
                case Status.SLEEP:
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
            Move move1 = actorSide.GetCurrentBattlePokemon().GetMove1();
            Move move2 = actorSide.GetCurrentBattlePokemon().GetMove2();
            Move move3 = actorSide.GetCurrentBattlePokemon().GetMove3();
            Move move4 = actorSide.GetCurrentBattlePokemon().GetMove4();

            Console.WriteLine("(1) " + move1.GetName() + " " + move1.GetCurrentPP() + "/" + move1.GetMaxPP());
            if (move2 != null)
            {
                Console.WriteLine("(2) " + move2.GetName() + " " + move2.GetCurrentPP() + "/" + move2.GetMaxPP());
            }
            if (move3 != null)
            {
                Console.WriteLine("(3) " + move3.GetName() + " " + move3.GetCurrentPP() + "/" + move3.GetMaxPP());
            }
            if (move4 != null)
            {
                Console.WriteLine("(4) " + move4.GetName() + " " + move4.GetCurrentPP() + "/" + move4.GetMaxPP());
            }
            Console.WriteLine("(0) - - - back - - -");
            Console.Write("Type number and press enter: ");
        }
    }
}
