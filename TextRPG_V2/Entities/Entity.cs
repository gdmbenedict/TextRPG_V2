using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2.Entities
{
    public enum Faction
    {

    }

    internal abstract class Entity
    {
        //Entity variables
        private string name; //the name of the Entity
        private ConsoleColor color; //color of the Entity respresentation
        private char symbol; //the graphical representation of the Entity
        private bool magic;

        //Stats
        public HealthSystem health; //the health value of the entity
        public Stat atk; //the damage the entity does with a physical attack
        public Stat def; //the reduction in damage the entity takes from physical attacks
        public Stat mag; //the damage the entity does with a magical attack
        public Stat res; //the reduction in damage the entity takes from magical attacks 
        public Stat spd; //the rate at which the entity can take turns (also used in avoid and hit calcs)
        public Stat skl; //Value used in hit, crit and avoid calculations
        public Stat luc; //Value used in hit, crit and avoid calculations

        //derived values

        /*
         * Avoid: The difficulty added to hit calculations (50 + 2*Spd + 2*Skl + Luc)
         * Hit: The gain added to hit calculations (3*Skl + Spd + Luc)
         * Crit: The chance to land a critical hit in an attack (0.4*Luc + 0.1*Skl)
         */

        //random number generation for Entity
        private Random rnd = new Random();

        /// <summary>
        /// Constructor for an Entity
        /// </summary>
        /// <param name="name">the name of the Entity</param>
        /// <param name="symbol">the graphical representation of the Entity</param>
        /// <param name="color">color of the Entity</param>
        /// <param name="atk">the damage the entity does with a physical attack</param>
        /// <param name="def">the reduction in damage the entity takes from physical attacks</param>
        /// <param name="mag">the damage the entity does with a magical attack</param>
        /// <param name="res">the reduction in damage the entity takes from magical attacks</param>
        /// <param name="spd">the rate at which the entity can take turns</param>
        /// <param name="skl">Value used in hit, crit and avoid calculations</param>
        /// <param name="luc">Value used in hit, crit and avoid calculations</param>
        public Entity(string name, char symbol, ConsoleColor color, int atk, int def, int mag, int res, int spd, int skl, int luc)
        {
            //Setting entity variables
            this.name = name;
            this.symbol = symbol;
            this.color = color;

            //Setting stat
            health = null;
            this.atk = new Stat(atk);
            this.def = new Stat(def);
            this.mag = new Stat(mag);
            this.res = new Stat(res);
            this.spd = new Stat(spd);
            this.skl = new Stat(skl);
            this.luc = new Stat(luc);
        }

        /// <summary>
        /// Empty constructor for an Entity
        /// </summary>
        public Entity()
        {
            name = null;
            symbol = '?';
            color = ConsoleColor.Gray;
            health = null;
            atk = null;
            def = null;
            mag = null;
            res = null;
            spd = null;
            skl = null;
            luc = null;
        }

        public abstract string ChooseAction();

        //TODO: tiles and map before this can be finished
        public string Move()
        {

        }

        public string Attack(Entity target)
        {
            string attackMessage = name + " attacked " + target.name;
            int damage;

            //get random roll
            int roll = rnd.Next(1,100);

            //get derived values
            int crit = (int)(0.4 * luc.GetStat() + 0.1 * skl.GetStat());
            int hit = 3 * skl.GetStat() + spd.GetStat() + luc.GetStat();
            int avoid = 50 + 2 * target.spd.GetStat() + 2 * target.skl.GetStat() + target.luc.GetStat();

            //check for critical hit
            if (roll >= 100 - crit)
            {
                damage = target.TakeDamage(GetAttackDamage() * 2, magic);

                attackMessage += GetAttackType() + "and CRITICALLY HIT for " + damage + " damage!!!";
            }

            //check for regular hit
            if (roll + hit > avoid)
            {
                damage = target.TakeDamage(GetAttackDamage(), magic);

                attackMessage += GetAttackType() + "and hit for " + damage + "damage.";
            }
            //attack missed
            else
            {
                attackMessage += " and missed.";  
            }

            return attackMessage;
        }

        /// <summary>
        /// Utility function to return the correct number for an attack's damage
        /// </summary>
        /// <returns>damage the entity does on a successful attack</returns>
        private int GetAttackDamage()
        {
            if (magic)
            {
                return mag.GetStat();
            }
            else
            {
                return atk.GetStat();
            }
        }

        /// <summary>
        /// Utility function to return the type of attack the entity does in a string
        /// </summary>
        /// <returns>string for the type of damage</returns>
        private string GetAttackType()
        {
            if (magic)
            {
                return " using magic ";
            }
            else
            {
                return " physically ";
            }
        }

        /// <summary>
        /// Method that reduced damage taken by the entity by the appropriate amount and returns the damage taken by the entity
        /// </summary>
        /// <param name="incomingDamage">the numerical value of the damage being applied</param>
        /// <param name="magic">whether or not the damage is magical</param>
        /// <returns>damage taken by the entity</returns>
        public int TakeDamage(int incomingDamage, bool magic)
        {
            int damage;

            if (magic)
            {
                damage = incomingDamage - res.GetStat();
            }
            else
            {
                damage = incomingDamage - def.GetStat();
            }

            //sets minimum damage amount
            if (damage < 0)
            {
                damage = 0;
            }

            //apply damage to health
            health.ModHp(- damage);

            //return the damage amount
            return damage;
        }


    }
}
