using PokemonGeneration1.Source.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Trainers
{
    public class ItemAndQuantity
    {
        public Item item;
        public int quantity;

        public ItemAndQuantity(Item item)
        {
            this.item = item;
            this.quantity = 1;
        }
    }
}
