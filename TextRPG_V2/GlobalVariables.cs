using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public static class GlobalVariables
    {
        //Entity Variables

        //Actions / Turns
        public const int actionThreshold = 100;

        //dodge
        public const int baseDodge = 50;
        public const int dodgeSpdWeight = 2;
        public const int dodgeSklWeight = 2;
        public const int dodgeLecWeight = 1;

        //hit
        public const int hitSklWeight = 3;
        public const int hitSpdWeight = 1;
        public const int hitLucWeight = 1;

        //avoid
        public const float critLucWeight = 0.4f;
        public const float critSklWeight = 0.1f;



        //Items
        public const int potionHealingValue = 10;
        public const int swordAtkIncrease = 5;
        public const int goldValue = 100;



        //Map Variables
        public const string filename = "Dungeon.txt";
        public const string directory = @"Maps\MapFiles\";



        //Camera
        public const int cameraHeight = 15;
        public const int cameraWidth = 31;
    }
}
