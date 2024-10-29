﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    internal class Settings
    {
        //Actions
        private int actionThreshhold;

        //Dodge
        private int baseDodge;
        private int dodgeSpedWeight;
        private int dodgeSklWeight;
        private int dodgeLucWeight;

        //Hit
        private int hitSklWeight;
        private int hitSpdWeight;
        private int hitLucWeight;

        //Crit
        private int crtiLucWeight;
        private int critSklWeight;

        //Items
        private int potionHealingValue;
        private int swordAtkIncrease;
        private int goldValue;

        //Camera
        public int cameraHeight;
        public int cameraWidth;

        //UI Windows
        public int windowPadding;

        public int statWindowHeight;
        public int statWindowWidth;

        public int controlsWindowHeight;
        public int controlsWindowWidth;

        public int eventLogWindowHeight;
        public int eventLogWindowWidth;
        public int macEventLogMessage;
        
    }
}
