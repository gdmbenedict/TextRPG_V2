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
        //File Paths DO NOT CHANGE!!!

        //Map Variables
        public static string mapFilename = "Dungeon.txt";
        public static string mapDirectory = @"Maps\MapFiles\";

        //Settings Variables
        public static string settingsFilename = "";
        public static string settingsDirectory = "";

        //Entity Variables

        //Actions / Turns (TODO: fix AP system to make updates faster)
        public static int actionThreshold = 10;

        //dodge
        public static int baseDodge = 50;
        public static int dodgeSpdWeight = 2;
        public static int dodgeSklWeight = 2;
        public static int dodgeLucWeight = 1;

        //hit
        public static int hitSklWeight = 3;
        public static int hitSpdWeight = 1;
        public static int hitLucWeight = 1;

        //Crit
        public static float critLucWeight = 0.4f;
        public static float critSklWeight = 0.1f;

        //Items
        public static int potionHealingValue = 10;
        public static int swordAtkIncrease = 5;
        public static int goldValue = 100;

        //Camera
        public static int cameraHeight = 21;
        public static int cameraWidth = 31;

        //UIWindows
        public static int windowPadding = 1;

        public static int statWindowHeight = 11;
        public static int statWindowWidth = 20;

        public static int controlsWindowHeight = 23;
        public static int controlsWindowWidth = 22;

        public static int EventLogWindowHeight = 12;
        public static int EventLogWindowWidth = 77;
        public static int maxEventLogMessage = 10;


    }
}
