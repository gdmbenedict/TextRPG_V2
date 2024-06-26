using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public class Camera
    {
        Entity target; //the target of the camera (normally the player) that will be followed
        private int displayHeight = GlobalVariables.cameraHeight + 2; //height of the display for the Camera (adjusted to have border)
        private int displayWidth = GlobalVariables.cameraWidth + 2; //width of the display for the Camera (adjusted to have border)

        /// <summary>
        /// Constructor for a Camera type object
        /// </summary>
        /// <param name="target">The target that camera will be following</param>
        public Camera(Entity target)
        {
            this.target = target;
        }

        /// <summary>
        /// Function that draws the game world to the UI
        /// </summary>
        /// <param name="map">The map that the game plays in</param>
        /// <param name="startPosCol">The y position at which to start drawing the gameplay UI</param>
        /// <param name="startPosRow">The x position at which to start drawing the gameplay UI</param>
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

            //drawing contents of map
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

        /// <summary>
        /// Accessor method that returns the adjusted width of the camera
        /// </summary>
        /// <returns>Adjusted width of the camera</returns>
        public int GetWidth()
        {
            return displayWidth;
        }

        /// <summary>
        /// Accessor method that returns the adjusted height of the cameraa
        /// </summary>
        /// <returns>Adjusted height of the camera</returns>
        public int GetHeight()
        {
            return displayHeight;
        }
    }
}
