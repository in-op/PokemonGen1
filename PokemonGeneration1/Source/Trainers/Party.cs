using PokemonGeneration1.Source.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Trainers
{
    public class Party
    {
        private Pokemon[] PartyPokemon;



        public Party()
        {
            this.PartyPokemon = new Pokemon[6];
        }



        public List<Pokemon> GetFullParty()
        {
            List<Pokemon> party = new List<Pokemon>(6);
            for (int i = 0; i < 6; i++)
            {
                if (PartyPokemon[i] != null)
                {
                    party.Add(PartyPokemon[i]);
                }
            }
            return party;
        }



        public bool IsPartyFull()
        {
            for (int i = 0; i < 6; i++)
            {
                if (this.PartyPokemon[i] == null)
                {
                    return false;
                }
            }
            return true;
        }
        
        

        public void Add(Pokemon pokemon) // will not add the pokemon if party is full
        {
            for (int i = 0; i < 6; i++)
            {
                if (this.PartyPokemon[i] == null)
                {
                    this.PartyPokemon[i] = pokemon;
                    return;
                }
            }
        }


        /// <summary>
        /// Auto-fills the party with the array of Pokemon.
        /// Used for making pre-made NPC trainers
        /// </summary>
        /// <param name="pokemon">Array of Pokemon to become the party for the NPC</param>
        public void Populate(Pokemon[] pokemon) //used for generating pre-made trainers
        {
            int length = pokemon.Length;
            for (int i = 0; i < length && i < 6; i++)
            {
                this.PartyPokemon[i] = pokemon[i];
            }
        }
    }
}
