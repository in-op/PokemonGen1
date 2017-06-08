using PokemonGeneration1.Source.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Trainers
{
    public class Trainer
    {
        private string Name;
        private Party Party;
        private Bag Bag;

        public string GetName() { return this.Name; }
        public void SetName(string name) { this.Name = name; }

        public List<Pokemon> GetParty()
        {
            return Party.GetFullParty();
        }
        public void AddToParty(Pokemon poke)
        {
            Party.Add(poke);
        }

        public Trainer(string name)
        {
            this.Name = name;
            this.Party = new Party();
            this.Bag = new Bag();
        }
        
    }
}
