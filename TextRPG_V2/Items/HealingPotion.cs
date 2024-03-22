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
            SetSymbol('p');
            SetColor(ConsoleColor.Green);
        }

        public override string Use(Entity target)
        {
            string message = target.GetName() + " used a " + GetName(); ;
            int oldHp = target.health.GetHp();

            target.health.ModHp(healing);

            message += " and healed " + (target.health.GetHp() - oldHp) + " hp.";

            return message;
        }
    }
}
