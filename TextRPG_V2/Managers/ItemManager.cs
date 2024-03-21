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
        private List<Item> items;

        public ItemManager() { 
        
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (item.Equals(null))
            {
                return;
            }

            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void UpdateItems()
        {
            //do things with items if necessary
        }

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
