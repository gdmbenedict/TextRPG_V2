using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    //Struct used to set up an initiative system
    public struct TurnCell
    {
        public Entity entity {  get; set; }
        public int turnBuildup {  get; set; }

        public int CompareTo(TurnCell other)
        {
            if (entity.spd.GetStat() > other.entity.spd.GetStat())
            {
                return 1;
            }
            else if(entity.spd.GetStat() < other.entity.spd.GetStat())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class EntityManager
    {
        List<TurnCell> turnCells;
        
        public EntityManager()
        {

        }

        public void AddEntity(Entity entity)
        {

        }

        public void RemoveEntity(Entity entity)
        {

        }
    }
}
