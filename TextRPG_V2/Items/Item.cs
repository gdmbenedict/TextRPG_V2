using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    internal abstract class Item
    {
        private string name; //name of the item

        /// <summary>
        /// Constructor method for an abstract item object
        /// </summary>
        /// <param name="name">name of the item</param>
        public Item(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Empty Constructor for an Item object
        /// </summary>
        public Item()
        {
            name = null;
        }

        /// <summary>
        /// Abstract method for using an item
        /// </summary>
        /// <param name="target">The entity that is using the item</param>
        /// <returns>A string for the event log</returns>
        public string Use(Entity target)
        {
            string useMessage;
            useMessage = target.GetName() + " used a " + name;

            return useMessage;
        }

        /// <summary>
        /// Accessor method for the name of the item
        /// </summary>
        /// <returns>name of the item</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Mutator
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            this.name = name;
        }


    }
}
