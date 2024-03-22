using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public class Camera
    {
        Entity target;
        private int displayHeight = GlobalVariables.cameraHeight + 2;
        private int displayWidth = GlobalVariables.cameraWidth + 2;

        public Camera(Entity target)
        {
            this.target = target;
        }

        public void DrawGamePlay(Map map, int startPosCol, int startPosRow)
        {
            int[] targetIndex = map.GetEntityIndex(target);
            int j, i;

            //draw top border
            Console.SetCursorPosition(startPosCol, startPosRow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("┌");
            for (i =0; i<GlobalVariables.cameraWidth; i++)
            {
                Console.Write('─');
            }
            Console.Write('┐');

            j = 0;
            for (int y = -(GlobalVariables.cameraHeight/2); y <= (GlobalVariables.cameraHeight/2); y++)
            {
                j++;

                //print border
                Console.SetCursorPosition(startPosCol, startPosRow + j);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('│');

                //print map
                for (int x = -(GlobalVariables.cameraWidth/2); x <= (GlobalVariables.cameraWidth/2); x++)
                {
                    //get index
                    int yPos = y + targetIndex[0];
                    int xPos = x + targetIndex[1];

                    //check if in boundaries of map
                    if ((yPos >= 0 && yPos < map.GetHeight()) && (xPos >= 0 && xPos < map.GetWidth()))
                    {
                        int[] index = { yPos, xPos };
                        Console.ForegroundColor = map.GetTopColor(index);
                        Console.Write(map.GetTopSymbol(index));
                    }
                    //not in boundaries, print space
                    else
                    {
                        Console.Write (' ');
                    }
                }

                //print border
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('│');
            }

            //draw bottom border
            Console.SetCursorPosition(startPosCol, startPosRow + j + 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('└');
            for (i = 0; i < GlobalVariables.cameraWidth; i++)
            {
                Console.Write('─');
            }
            Console.Write('┘');

        }

        public int GetWidth()
        {
            return displayWidth;
        }

        public int GetHeight()
        {
            return displayHeight;
        }
    }
}
