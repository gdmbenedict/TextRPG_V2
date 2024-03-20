using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2.Items
{
    public class HealingPotion : Item
    {
        private int healing;

        public HealingPotion() : base("healing potion")
        {
            healing = GlobalVariables.potionHealingValue;
        }

        new public string Use(Entity target)
        {
            string message = base.Use(target);
            int oldHp = target.health.GetHp();

            target.health.ModHp(healing);

            message += " and healed " + target.health.GetHp() + " hp.";

            return message;
        }
    }
}
