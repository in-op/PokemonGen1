using PokemonGeneration1.Source.PokemonData;
using System;

namespace PokemonStadiumConsoleApp
{
    public static class SelectPokemon
    {
        public static Pokemon Choose()
        {
            int input = int.MinValue;

            while (input < 1 || input > 149)
            {
                Console.Clear();
                Display149Pokemon();
                Console.Write("Enter selection: ");
                while (!Int32.TryParse(Console.ReadLine(), out input))
                {
                    Console.Clear();
                    Display149Pokemon();
                    Console.Write("Enter selection: ");
                }
                
            }

            Console.Clear();
            return PrimeCupRentalPokemonFactory.Create(input);
        }

        private static void DisplayAllPokemon()
        {
            string line;
            for (int i = 1; i < 52; i++)
            {
                line = Display.LeftJustify(i + " | " + SpeciesData.Names[i], 24);
                line +=
                    Display.LeftJustify((i + 51) + " | " + SpeciesData.Names[i + 51],
                                        24);
                if (i < 50)
                {
                    line +=
                    Display.LeftJustify((i + 102) + " | " + SpeciesData.Names[i + 102],
                                        24);
                }
                
                Console.WriteLine(line);
            }
        }

        private static void Display149Pokemon()
        {
            string line;
            for (int i = 1; i < 51; i++)
            {
                line =
                    Display.LeftJustify(i + " | " + SpeciesData.Names[i],
                                        24);
                line +=
                    Display.LeftJustify((i + 50) + " | " + SpeciesData.Names[i + 50],
                                        24);
                if (i < 50)
                {
                    line +=
                Display.LeftJustify((i + 100) + " | " + SpeciesData.Names[i + 100],
                                        24);
                }

                Console.WriteLine(line);
            }
        }
    }
}
