using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2.Items
{
    public class Sword : Item
    {
        int atkIncrease;

        public Sword() : base("Sword") 
        {
            atkIncrease = GlobalVariables.swordAtkIncrease;
        }

        new public string Use(Entity target)
        {
            string message = base.Use(target);
            int oldAtk = target.atk.GetStat();

            target.atk.ModStat(atkIncrease);

            message += " and increased their atk by " + (target.atk.GetStat() - oldAtk) + "."; 

            return message;
        }
    }
}
