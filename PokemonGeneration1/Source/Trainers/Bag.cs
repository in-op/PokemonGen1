using PokemonGeneration1.Source.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Trainers
{
    //implementation readme: 
    //  array has 20 slots for item-quantity tuples
    //  adding to bag fills up aray from index 0 to 20, and inverse for removing
    //  each slot can hold up to 99x of its item
    //  if more than 99x item are added, the next flow over to a new slot
    //  **empty slots are null*
    public class Bag
    {
        private ItemAndQuantity[] Holder; //elt1: item; elt2: quantity
        


        public Bag()
        {
            this.Holder = new ItemAndQuantity[20];
        }
        


        public bool CanAdd(Item item)
        {
            for (int i = 0; i < 20; i++)
            {
                if (Holder[i] == null) return true;
                else if (Holder[i].item == item && Holder[i].quantity < 99) return true;
            }
            return false;
        }



        public void Add(Item item) //won't add the item if it cant fit it
        {
            for (int i = 0; i < 20; i++)
            {
                if (Holder[i] == null)
                {
                    Holder[i] = new ItemAndQuantity(item);
                    return;
                }
                else if (Holder[i].item == item &&
                         Holder[i].quantity < 99)
                {
                    Holder[i].quantity++;
                    return;
                }
            }
        }



        public void Remove(Item item) //won't do anything if the input item doesn't actually exist in the Bag
        {
            for (int i = 0; i < 20; i++)
            {
                if (Holder[i] != null && Holder[i].item == item)
                {
                    if (Holder[i].quantity > 1) Holder[i].quantity--;
                    else Holder[i] = null;
                    return;
                }
            }
        }
    }
}
