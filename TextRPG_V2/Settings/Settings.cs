using System;
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
        private int dodgeSpdWeight;
        private int dodgeSklWeight;
        private int dodgeLucWeight;

        //Hit
        private int hitSklWeight;
        private int hitSpdWeight;
        private int hitLucWeight;

        //Crit
        private float critLucWeight;
        private float critSklWeight;

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
        public int maxEventLogMessage;
        
        //Empty constructor
        public Settings(string path)
        {
            
        }

        public void SaveSettings()
        {
            // https://www.youtube.com/watch?v=Y14gG9IJ230
        }

        public void LoadSettings()
        {
            //Action Settings
            GlobalVariables.actionThreshold = actionThreshhold;

            //Dodge settings
            GlobalVariables.baseDodge = baseDodge;
            GlobalVariables.dodgeSpdWeight = dodgeSpdWeight;
            GlobalVariables.dodgeSklWeight = dodgeSklWeight;
            GlobalVariables.dodgeLucWeight = dodgeLucWeight;

            //Hit Settings
            GlobalVariables.critLucWeight = critLucWeight;
            GlobalVariables.critSklWeight = critSklWeight;

            //Items
            GlobalVariables.potionHealingValue = potionHealingValue;
            GlobalVariables.swordAtkIncrease = swordAtkIncrease;
            GlobalVariables.goldValue = goldValue;

            //Camera
            GlobalVariables.cameraHeight = cameraHeight;
            GlobalVariables.cameraWidth = cameraWidth;

            //UI Windows
            GlobalVariables.windowPadding = windowPadding;

            GlobalVariables.statWindowHeight = statWindowHeight;
            GlobalVariables.statWindowWidth = statWindowWidth;

            GlobalVariables.controlsWindowHeight = controlsWindowHeight;
            GlobalVariables.controlsWindowWidth = controlsWindowWidth;

            GlobalVariables.EventLogWindowHeight = eventLogWindowHeight;
            GlobalVariables.EventLogWindowWidth = eventLogWindowWidth;
            GlobalVariables.maxEventLogMessage = maxEventLogMessage;
        }
    }
}
