using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    internal class BootsOfSpeed : Item
    {

        public BootsOfSpeed() : base()
        {

        }

        new public string Use(Entity target)
        {
            string message = base.Use(target);
            message += " and maxed their speed";

            target.spd.SetStat(target.spd.GetMaxStat());

            return message;
        }
    }
}
