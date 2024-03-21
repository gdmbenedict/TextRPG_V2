using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    internal class Warrior : Entity
    {
        private enum Direction
        {
            north,
            east,
            south,
            west
        }

        private Direction direction;

        public Warrior() {

            SetName("Warrior");
            SetSymbol('w');
            SetColor(ConsoleColor.Red);
            SetFaction(Faction.warriors);
            SetMagic(false);

            health = new HealthSystem(20);
            atk = new Stat(10);
            def = new Stat(10);
            mag = new Stat(1);
            res = new Stat(7);
            spd = new Stat(6);
            skl = new Stat(4);
            luc = new Stat(10);

            ChooseDirection();
        }

        /// <summary>
        /// Moves in a line until it finds an impassable tile or another entity
        /// </summary>
        /// <param name="map"></param>
        /// <param name="startPos"></param>
        /// <returns></returns>
        public override string ChooseAction(Map map, int[] startPos, UIManager uiManager, ItemManager itemManager)
        {
            bool foundDirection = false;
            int[] endPos = new int[2];

            int[] posNorth = { startPos[0] - 1, startPos[1] };
            int[] posSouth = { startPos[0] + 1, startPos[1] };
            int[] posEast = { startPos[0], startPos[1] - 1 };
            int[] posWest = { startPos[0], startPos[1] + 1 };

            //checks for entities
            if (map.GetEntity(posSouth) != null)
            {
                return Move(map, startPos, posSouth, uiManager, itemManager);
            }
            else if (map.GetEntity(posWest) != null)
            {
                return Move(map, startPos, posWest, uiManager, itemManager);
            }
            else if (map.GetEntity(posNorth) != null)
            {
                return Move(map, startPos, posNorth, uiManager, itemManager);
            }
            else if (map.GetEntity(posEast) != null)
            {
                return Move(map, startPos, posEast, uiManager, itemManager);
            }

            while (!foundDirection)
            {
                switch (direction)
                {
                    //try north
                    case Direction.north:
                        if (!map.GetTile(posNorth).GetImpassable())
                        {
                            endPos = posNorth;
                            foundDirection = true;
                        }
                        else
                        {
                            ChooseDirection();
                        }
                        break;

                    //try east
                    case Direction.east:
                        if (!map.GetTile(posEast).GetImpassable())
                        {
                            endPos = posEast;
                            foundDirection = true;
                        }
                        else
                        {
                            ChooseDirection();
                        }
                        break;

                    //try south
                    case Direction.south:
                        if (!map.GetTile(posSouth).GetImpassable())
                        {
                            endPos = posSouth;
                            foundDirection = true;
                        }
                        else
                        {
                            ChooseDirection();
                        }
                        break;

                    //try west
                    case Direction.west:
                        if (!map.GetTile(posWest).GetImpassable())
                        {
                            endPos = posWest;
                            foundDirection = true;
                        }
                        else
                        {
                            ChooseDirection();
                        }
                        break;
                    
                }
            }

            return Move(map, startPos, endPos, uiManager, itemManager);
        }

        private void ChooseDirection()
        {
            switch (rnd.Next(0, 4))
            {
                case 0:
                    direction = Direction.north;
                    break;

                case 1:
                    direction = Direction.east;
                    break;

                case 2:
                    direction = Direction.south;
                    break;

                case 3:
                    direction = Direction.west;
                    break;
            }
        }
    }
}
