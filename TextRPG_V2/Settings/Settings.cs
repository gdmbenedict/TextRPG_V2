using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TextRPG_V2
{
    internal class Settings
    {
        //Actions
        public int actionThreshhold { get; set; }

        //Dodge
        public int baseDodge { get; set; }
        public int dodgeSpdWeight { get; set; }
        public int dodgeSklWeight { get; set; }
        public int dodgeLucWeight { get; set; }

        //Hit
        public int hitSklWeight { get; set; }
        public int hitSpdWeight { get; set; }
        public int hitLucWeight { get; set; }

        //Crit
        public float critLucWeight { get; set; }
        public float critSklWeight { get; set; }

        //Items
        public int potionHealingValue { get; set; }
        public int swordAtkIncrease { get; set; }
        public int goldValue { get; set; }

        //Camera
        public int cameraHeight { get; set; }
        public int cameraWidth { get; set; }

        //UI Windows
        public int windowPadding { get; set; }

        public int statWindowHeight { get; set; }
        public int statWindowWidth { get; set; }

        public int controlsWindowHeight { get; set; }
        public int controlsWindowWidth { get; set; }

        public int eventLogWindowHeight { get; set; }
        public int eventLogWindowWidth { get; set; }
        public int maxEventLogMessage { get; set; }

        //Empty constructor
        public Settings()
        {
           
        }

        public void SaveSettings()
        {
            
        }

        public void ApplySettings()
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
