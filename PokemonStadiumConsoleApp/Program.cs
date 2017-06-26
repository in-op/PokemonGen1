using PokemonGeneration1.Source.Battles;
using PokemonGeneration1.Source.PokemonData;
using PokemonGeneration1.Source.Trainers;
using System;
using System.Threading;

namespace PokemonStadiumConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Clear();



            Console.WriteLine("Select your pokemon: ");
            Thread.Sleep(2000);
            Pokemon playersPokemon = SelectPokemon.Choose();
            Console.Clear();
            Console.WriteLine("Select opponent's pokemon: ");
            Thread.Sleep(2000);
            Pokemon enemyPokemon = SelectPokemon.Choose();
            Console.Clear();



            Trainer Player = new Trainer(name);
            Player.AddToParty(playersPokemon);


            Side playerSide = new TrainerSide(Player);
            Side enemySide = new WildPokemonSide(enemyPokemon);

            ConsoleBattlePlayer.Run(playerSide, enemySide, new RandomWildPokemonActor());

            Console.Write("Press enter to exit");
            Console.ReadLine();
        }
    }
}
