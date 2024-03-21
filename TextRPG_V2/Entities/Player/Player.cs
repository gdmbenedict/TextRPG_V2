using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG_V2
{
    public class Player : Entity
    {
        

        public Player() : base() 
        {
            SetName("Player");
            SetSymbol('@');
            SetColor(ConsoleColor.Yellow);
            base.health = new HealthSystem(15);
            base.atk = new Stat(5);
            base.def = new Stat(5);
            base.mag = new Stat(5);
            base.res = new Stat(5);
            base.spd = new Stat(10);
            base.skl = new Stat(10);
            base.luc = new Stat(10);

        }

        public override string ChooseAction(Map map, int[] startPos)
        {
            //declaring variables
            int[] endPos = { startPos[0], startPos[1] };

            //getting input from player
            ConsoleKeyInfo input = Console.ReadKey();

            //switch statement to determine which tile to move to
            switch (input.Key)
            {
                //move up
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    endPos[0]--;
                    break;

                //move down
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    endPos[0]++;
                    break;

                //move leftw
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    endPos[1]--;
                    break;

                //move right
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    endPos[1]++;
                    break;

                //switch stance
                case ConsoleKey.E:
                    return SwitchStance();
                    break;

                //close the game
                case ConsoleKey.Escape:
                    System.Environment.Exit(0);
                    break;
            }

            return Move(map, startPos, endPos);
        }

        new public string Move(Map map, int[] startPos, int[] endPos)
        {
            //check desired position if within bounds of map
            if (endPos[0] < 0 || endPos[0] >= map.GetHeight() || endPos[1] < 0 || endPos[1] >= map.GetWidth())
            {
                return null; //fail to move
            }

            //checks if there is an Entity to attack
            else if (map.GetEntity(endPos) != null)
            {
                return Attack(map.GetEntity(endPos)); //attacks entity
            }

            //uses item if item is available
            else if (map.GetItem(endPos) != null)
            {
                return map.GetItem(endPos).Use(this);
            }

            //check if Tile is impassableS
            else if (map.GetTile(endPos).GetImpassable())
            {
                return null; //fail to move
            }

            //moves
            else
            {
                //deal damage to player standing on dangerous tile
                if (map.GetTile(endPos).GetDangerous())
                {
                    map.GetTile(endPos).DealDamage(this);
                }

                map.AddEntity(map.GetEntity(startPos), endPos); //puts entity into new location
                map.RemoveEntity(startPos); //removes entity from old location

                return null;
            }
        }

        public string SwitchStance()
        {
            string message = "Player switched to ";

            SetMagic(!GetMagic());

            if (GetMagic())
            {
                message += "magic stance.";
            }
            else
            {
                message += "physical stance.";
            }

            return message;
        }
    }
}
