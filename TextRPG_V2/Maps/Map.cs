using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_V2;
using System.IO;

namespace TextRPG_V2
{
    public class Map
    {
        private string mapName;
        private Tile[,] background;
        private Entity[,] entities;
        private Item[,] items;
        private int height;
        private int width;

        public Map(string path, EntityManager entityManager, ItemManager itemManager)
        {
            //declaring some variables (default values added to handle no value error)
            int startIndex = 0, endIndex = 0;

            //check if file exists
            if (!File.Exists(@path))
            {
                //throw an error
            }

            //getting input from file
            string[] input = File.ReadAllLines(@path);

            //parsing through file for basic information
            //this section needs to be changed to fit JSON file format later
            mapName = input[0];

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "{")
                {
                    startIndex = i + 1; //sets start of map below open bracket
                }

                if (input[i] == "}")
                {
                    endIndex = i - 1; //sets end of map above closed bracket
                    break;
                }
            }

            if (!(endIndex >= startIndex))
            {
                //throw error
            }

            height = endIndex - startIndex + 1; //gets height of map
            width = input[startIndex].Length; //gets width of map

            //initializing Tile map
            background = new Tile[height, width];
            items = new Item[height, width];

            //cycle through every char of the input map
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //sets each individual tile to their correct value
                    background[y, x] = new Tile(input[y + startIndex][x]);
                }

            }

            //find start and end indexes for entities
            for (int i = endIndex + 1; i < input.Length; i++)
            {
                if (input[i] == "{")
                {
                    startIndex = i + 1; //sets start of map below open bracket
                }

                if (input[i] == "}")
                {
                    endIndex = i - 1; //sets end of map above closed bracket
                    break;
                }
            }

            //initializing entity map
            entities = new Entity[height, width];

            //reading in and adding in entities
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    entities[y, x] = entityManager.InitializeEntity(input[y + startIndex][x]);
                    entityManager.AddEntity(entities[y, x]);
                }
            }

            //find start and end indexes for items
            for (int i = endIndex + 1; i < input.Length; i++)
            {
                if (input[i] == "{")
                {
                    startIndex = i + 1; //sets start of map below open bracket
                }

                if (input[i] == "}")
                {
                    endIndex = i - 1; //sets end of map above closed bracket
                    break;
                }
            }

            //initializing item map
            items = new Item[height, width];

            //reading in and adding to item manager
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    items[y, x] = itemManager.InitializeItem(input[y + startIndex][x]);
                    itemManager.AddItem(items[y, x]);
                }
            }
        }

        /*
         * Accessor method for Height of the Map
         * Output: (int) height: the length of a column of the map array
         */
        public int GetHeight()
        {
            return height;
        }

        /*
         * Accessor method for the width of Map
         * Output: (int) width: the width of a row of the map array
         */
        public int GetWidth()
        {
            return width;
        }

        /*
         * Accessor method for specified Tile in map background
         * Input: (int[]) pos: position of the Tile on the map background
         *      pos[0]: the Y coordinate of the Tile
         *      pos[1]: the X coordinate of the Tile
         */
        public Tile GetTile(int[] pos)
        {
            return background[pos[0], pos[1]];
        }

        /*
         * Accessor method for specified Entity in map entities
         * Input: (int[]) pos: position of the Entity on the map entities
         *      pos[0]: the Y coordinate of the Entity
         *      pos[1]: the X coordinate of the Entity
         */
        public Entity GetEntity(int[] pos)
        {
            return entities[pos[0], pos[1]];
        }

        /*
         * Mutator method that sets an Entity's position on the Map entities
         * Input: (Entity) entity: the desired entity to be placed in Map entities
         * Input: (int[]) pos: position of the Entity on the map entities
         *      pos[0]: the Y coordinate of the Entity
         *      pos[1]: the X coordinate of the Entity
         */
        public void AddEntity(Entity entity, int[] pos)
        {
            entities[pos[0], pos[1]] = entity;
        }

        /*
         * Mutator method that removes an Entity from the Map entities
         * Input: (int[]) pos: position of the Entity on the map entities
         *      pos[0]: the Y coordinate of the Entity
         *      pos[1]: the X coordinate of the Entity
         */
        public void RemoveEntity(int[] pos)
        {
            entities[pos[0], pos[1]] = null;
        }

        public void RemoveEntity(Entity entity)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int[] index = { y, x };
                    if (entities[index[0], index[1]] == entity)
                    {
                        entities[index[0], index[1]] = null;
                    }
                }
            }
        }

        /// <summary>
        /// Accessor method that returns the index for a specific instance of an Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int[] GetEntityIndex(Entity entity)
        {
            for (int y =0; y<height; y++)
            {
                for (int x =0; x<width; x++)
                {
                    int[] index = {y, x}; 
                    if (entities[index[0], index[1]] == entity)
                    {
                        return index;
                    }
                }
            }

            return null;
        }

        public Item GetItem(int[] pos)
        {
            return items[pos[0], pos[1]];
        }

        public void AddItem(Item item, int[] pos)
        {
            items[pos[0], pos[1]] = item;
        }

        public void RemoveItem(int[] pos)
        {
            items[pos[0], pos[1]] = null;
        }

        public ConsoleColor GetTopColor(int[] pos)
        {
            if (entities[pos[0], pos[1]] != null)
            {
                return entities[pos[0], pos[1]].GetColor();
            }
            else if (items[pos[0], pos[1]] != null)
            {
                return items[pos[0], pos[1]].GetColor();
            }
            else
            {
                return background[pos[0], pos[1]].GetColor();
            }
        }

        public char GetTopSymbol(int[] pos)
        {
            if (entities[pos[0], pos[1]] != null)
            {
                return entities[pos[0], pos[1]].GetSymbol();
            }
            else if (items[pos[0], pos[1]] != null)
            {
                return items[pos[0], pos[1]].GetSymbol();
            }
            else
            {
                return background[pos[0], pos[1]].GetSymbol();
            }
        }
    }
}

