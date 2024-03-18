using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public static class GlobalVariables
    {
        //Entity Variables

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
    }
}
