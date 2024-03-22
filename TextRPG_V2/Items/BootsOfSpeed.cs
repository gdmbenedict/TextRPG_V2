using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public class BootsOfSpeed : Item
    {

        public BootsOfSpeed() : base("Boots of Speed")
        {
            SetSymbol('b');
            SetColor(ConsoleColor.DarkCyan);
        }

        public override string Use(Entity target)
        {
            string message = target.GetName() + " used a " + GetName(); ;
            message += " and maxed their speed";

            target.spd.SetStat(target.spd.GetMaxStat());

            return message;
        }
    }
}
