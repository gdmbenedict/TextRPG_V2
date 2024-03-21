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

        public TurnCell(Entity entity)
        {
            this.entity = entity;
            turnBuildup = 0;
        }

        private string UpdateCell(Map map)
        {
            turnBuildup += entity.spd.GetStat();

            if (turnBuildup >= GlobalVariables.actionThreshold)
            {
                return TakeAction(map);
            }
            else
            {
                return null;
            }
        }

        private string TakeAction(Map map)
        {
            turnBuildup -= GlobalVariables.actionThreshold;
            return entity.ChooseAction(map, map.GetEntityIndex(entity));
        }

        //method used for potentially sorting list by speed
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
        private List<TurnCell> turnCells;
        private Map map;
        
        public EntityManager()
        {
            turnCells = new List<TurnCell>();
        }

        public void SetMap(Map map)
        {
            this.map = map;
        }

        public void AddEntity(Entity entity)
        {
            if (entity.Equals(null))
            {
                return;
            }

            turnCells.Add(new TurnCell(entity));
        }

        public void RemoveEntity(Entity entity)
        {
            foreach (TurnCell turnCell in turnCells)
            {
                if (turnCell.entity == entity)
                {
                    turnCells.Remove(turnCell);
                }
            }
        }

        public Entity InitializeEntity(char input)
        {
            switch (input)
            {
                case '@':
                    return new Player();

                case 'm':
                    return new Mage();

                case 'f':
                    return new Warrior();

                case 's':
                    return new Skeleton();

                default:
                    return null;
            }
        }

        public void UpdateEntities()
        {
            
        }

        public Entity GetPlayer()
        {
            foreach(TurnCell turnCell in turnCells)
            {
                if (turnCell.entity.GetName() == "Player")
                {
                    return turnCell.entity;
                }
            }

            return null;
        }
       
    }
}
