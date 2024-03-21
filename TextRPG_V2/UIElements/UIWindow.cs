using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public class UIWindow
    {
        private int width;
        private int height;
        private int stringLength;

        private char[,] contents;

        public UIWindow(int width, int height)
        {
            stringLength = width-2;

            contents = new char[width, height];

            //top boundary
            contents[0, 0] = '┌';
            for (int i=1; i < width-2; i++)
            {
                contents[0, i] = '─';
            }
            contents[0,width-1] = '┐';

            //side boundaries
            for (int j=1; j < height -2; j++)
            {
                contents[j, 0] = '│';
                contents[j, width-1] = '|';
            }

            //bottom boundary
            contents[height -1, 0] = '└';
            for (int i = 1; i < width - 2; i++)
            {
                contents[height - 1, i] = '─';
            }
            contents[height - 1, width - 1] = '┘';
        }

        public void printWindow(int[] startpos)
        {
            for (int y=0; y<height; y++)
            {
                for (int x=0; x<width; x++)
                {
                    Console.SetCursorPosition(startpos[0] +y, startpos[1] +x);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(contents[y,x]) ;
                }
            }
        }

        public void AddLine(int linePos, string input)
        {
            if (linePos <= 0 || linePos >= height-1)
            {
                return;
            }

            if (input.Length > stringLength)
            {
                return;
            }

            for (int i=0; i<input.Length; i++)
            {
                contents[linePos, 1+i] = input[i];
            }
        }

        public void ClearContents()
        {
            for(int j=1; j<height-2; j++)
            {
                for (int i=1; i<width-2; i++)
                {
                    contents[j, i] = ' ';
                }
            }
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }
    }
}
