using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    internal class Stat
    {
        private int statNum; //the numerical value of the stat
        private int minStat; //the minimum number the stat can reach
        private int maxStat; //the maximum number the stat can reach
        private bool capped; //bool tracking if the stat is capped

        /// <summary>
        /// Constructor for the Stat class taking only the stat number  
        /// </summary>
        /// <param name="statNum">the numerical value of the stat</param>
        public Stat(int statNum)
        {
            //setting secondary stat values
            maxStat = 99;
            minStat = 1;
            capped = true;

            //Checking stat boundaries and setting the stat number
            if (statNum > maxStat)
            {
                this.statNum = maxStat;
            }
            else if (statNum < minStat) 
            {
                this.statNum = minStat;
            }
            else
            {
                this.statNum = statNum;
            }
        }

        /// <summary>
        /// Overloaded constructor method for the Stat class, taking the stat number and the max stat
        /// </summary>
        /// <param name="statNum">the numerical value of the stat</param>
        /// <param name="maxStat">the maximum number the stat can reach</param>
        public Stat(int statNum, int maxStat)
        {
            //setting secondary stat values
            this.maxStat = maxStat;
            minStat = 1;
            capped = true;

            //Checking stat boundaries and setting the stat number
            if (statNum > maxStat)
            {
                this.statNum = maxStat;
            }
            else if (statNum < minStat)
            {
                this.statNum = minStat;
            }
            else
            {
                this.statNum = statNum;
            }
        }

        /// <summary>
        /// Overloaded constructor method for the Stat class, taking the stat number, the max stat, and the min stat
        /// </summary>
        /// <param name="statNum">the numerical value of the stat</param>
        /// <param name="maxStat">the maximum number the stat can reach</param>
        /// <param name="minStat">the minimum number the stat can reach</param>
        public Stat(int statNum, int maxStat, int minStat)
        {
            //setting secondary stat values
            this.maxStat = maxStat;
            this.minStat = minStat;
            capped = true;

            //Checking stat bounderies and setting the stat number
            if (statNum > maxStat)
            {
                this.statNum = maxStat;
            }
            else if (statNum < minStat)
            {
                this.statNum = minStat;
            }
            else
            {
                this.statNum = statNum;
            }
        }

        /// <summary>
        /// Mutator method that sets the stat number to the specified amount
        /// </summary>
        /// <param name="statNum">the desired number for the stat</param>
        /// <returns>bool indicating if the operation was successful</returns>
        public bool SetStat(int statNum)
        {
            //Checking stat boundaries and setting the stat number
            if (statNum > maxStat && capped)
            {
                //check if it is already the max stat
                if (this.statNum == maxStat)
                {
                    return false;
                }

                //change to max value
                this.statNum = maxStat;
                return true;
            }
            else if (statNum < minStat)
            {
                //check if it is already the min value
                if (this.statNum == minStat)
                {
                    return false;
                }

                //change to min value
                this.statNum = minStat;
                return true;
            }
            else
            {
                //change to set value
                this.statNum = statNum;
                return true;
            }
        }

        /// <summary>
        /// Mutator method that changes a stat number by a specified amount
        /// </summary>
        /// <param name="statNumMod">The amount by which the stat will be modified</param>
        /// <returns>bool indicating if the operation was successful</returns>
        public bool ModStat(int statNumMod)
        {
            //checking boundaries before setting stat
            if (statNum + statNumMod > maxStat && capped)
            {
                //checking if already at max
                if (statNum == maxStat)
                {
                    return false;
                }

                statNum = maxStat;
                return true;
            }
            else if (statNum + statNumMod < minStat)
            {
                //checking if already at min
                if (statNum == minStat)
                {
                    return false;
                }

                statNum = minStat;
                return true;
            }
            else
            {
                //modifying stat
                statNum += statNumMod;
                return true;
            }
        }

        /// <summary>
        /// Accessor method for the stat number of the stat
        /// </summary>
        /// <returns>The stat number of the stat</returns>
        public int GetStat()
        {
            return statNum;
        }

        /// <summary>
        /// Mutator method that sets the max stat of a stat to the desired number
        /// </summary>
        /// <param name="maxStat">the desired maximum stat value for a stat</param>
        /// <returns>bool indicating if the operation was successful</returns>
        public bool SetMaxStat(int maxStat)
        {
            //checks boundaries
            if (maxStat <= minStat)
            {
                //sets to the bottom of the bourdary
                if (this.maxStat > minStat + 1)
                {
                    this.maxStat = minStat + 1;
                    return true;
                }

                return false;
            }
            else
            {
                this.maxStat = maxStat;
                return true;
            }
        }

        /// <summary>
        /// Mutator method that modifies the maximum stat value of the stat by a desired number
        /// </summary>
        /// <param name="maxStatMod">the amount by which the maximum value of the stat will be changed</param>
        /// <returns>bool indicating if the operation was successful</returns>
        public bool ModMaxStat(int maxStatMod)
        {
            //checks boundaries
            if (maxStat + maxStatMod <= minStat)
            {
                //sets to the bottom of the bourdary
                if (this.maxStat > minStat + 1)
                {
                    maxStat = minStat + 1;
                    return true;
                }

                return false;
            }
            else
            {
                this.maxStat += maxStatMod;
                return true;
            }
        }

        /// <summary>
        /// Accessor method for the maximum value of a stat
        /// </summary>
        /// <returns></returns>
        public int GetMaxStat()
        {
            return maxStat;
        }

        /// <summary>
        /// Mutator method that sets the minimum stat value for a stat to the specified amount
        /// </summary>
        /// <param name="minStat">the desired number for the minimum value of the stat</param>
        /// <returns>bool indicating if the operation was successful</returns>
        public bool SetMinStat(int minStat)
        {
            //check the boundaries
            if (minStat < 1)
            {
                return false;
            }
            else if (minStat >= maxStat)
            {
                //sets to top of the boundary
                if (this.minStat < maxStat - 1)
                {
                    this.minStat = maxStat - 1;
                    return true;
                }

                return false;
            }
            else
            {
                this.minStat = minStat;
                return true;
            }
        }

        /// <summary>
        /// Mutator method that modifies the minumum stat value for a stat by a specified amount
        /// </summary>
        /// <param name="MinStatMod">the desired amount by which the minimum stat will be modified</param>
        /// <returns>bool indicating if the operation was successful</returns>
        public bool ModMinStat(int MinStatMod)
        {
            //check the boundaries
            if (minStat + MinStatMod < 1)
            {
                return false;
            }
            else if (minStat + MinStatMod >= maxStat)
            {
                //sets to top of the bourdary
                if (minStat < maxStat -1)
                {
                    minStat = maxStat - 1;
                    return true;
                }

                return false;
            }
            else
            {
                minStat += MinStatMod;
                return true;
            }
        }

        /// <summary>
        /// Accessor method for the minimum value of the stat
        /// </summary>
        /// <returns>the minimum value of the stat</returns>
        public int GetMinStat()
        {
            return minStat;
        }

        /// <summary>
        /// Mutator Method that sets whether a stat is capped or not
        /// </summary>
        /// <param name="capped">the desired capped state of the stat</param>
        /// <returns>bool indicating if the operation was successful</returns>
        public bool SetCapped(bool capped)
        {
            if (this.capped == capped)
            {
                return false;
            }
            else
            {
                this.capped = capped;
                return true;
            }
        }

        /// <summary>
        /// Accessor method for the capped state of the stat
        /// </summary>
        /// <returns>the capped state of the stat</returns>
        public bool GetCapped()
        {
            return capped;
        }

    }
}
