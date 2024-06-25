using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_V2.Items;

namespace TextRPG_V2
{

    public class ItemManager
    {
        private List<Item> items; //list of all items in the game

        /// <summary>
        /// Constructor method for a "Item Manager" object.
        /// </summary>
        public ItemManager() { 
        
            items = new List<Item>();
        }

        /// <summary>
        /// Mutator method that adds an input item to the list of items
        /// </summary>
        /// <param name="item">The Item that will be put in to the list of items</param>
        public void AddItem(Item item)
        {
            if (item != null)
            {
                items.Add(item);
            }
        }

        /// <summary>
        /// Mutator method that removes a specified item from the list of items
        /// </summary>
        /// <param name="item">Item that will be removed from the list</param>
        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        /// <summary>
        /// Method to update all items in the item list
        /// </summary>
        public void UpdateItems()
        {
            //do things with items if necessary
        }

        /// <summary>
        /// Method that initializes an Item from its character input
        /// </summary>
        /// <param name="input">character representing that item to be initialized</param>
        /// <returns>Item object that was initialized</returns>
        public Item InitializeItem(char input)
        {
            switch (input)
            {
                case 'p':
                    return new HealingPotion();

                case 's':
                    return new Sword();

                case 'b':
                    return new BootsOfSpeed();

                default:
                    return null;
            }
        }
    }
}
