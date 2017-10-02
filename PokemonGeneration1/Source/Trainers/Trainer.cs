using PokemonGeneration1.Source.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonGeneration1.Source.Trainers
{
    public class Trainer
    {
        public string Name { get; private set; }

        private List<Pokemon> party;
        private Bag bag;
        
        /// <summary>
        /// Adds the given Pokemon to the party if it is not already full.
        /// </summary>
        /// <param name="pokemon">The Pokemon to add.</param>
        public void AddToParty(Pokemon pokemon)
        {
            if (party.Count < 6) party.Add(pokemon);
        }

        /// <summary>
        /// Returns a list of the Trainer's party of Pokemon.
        /// </summary>
        /// <returns>A list of the Trainer's party of Pokemon.</returns>
        public List<Pokemon> Party() => party.ToList();
        
        /// <summary>
        /// Returns a new Trainer with the given name, an empty Pokemon party, and an empty Bag.
        /// </summary>
        /// <param name="name">The name of the Trainer.</param>
        public static Trainer CreateNew(string name) =>
            new Trainer(name, new List<Pokemon>(6), new Bag());


        public static Trainer Create(string name, List<Pokemon> party)
        {
            return new Trainer(name, party, new Bag());
        }


        private Trainer(
            string name,
            List<Pokemon> party,
            Bag bag)
        {
            Name = name;
            this.party = party;
            this.bag = bag;
        }

    }
}
