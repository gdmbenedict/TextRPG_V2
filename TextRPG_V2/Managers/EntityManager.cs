using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    //Struct used to set up an initiative system
    public class TurnCell
    {
        public Entity entity {  get; set; }
        public int turnBuildup {  get; set; }

        public TurnCell(Entity entity)
        {
            this.entity = entity;
            turnBuildup = 0;
        }

        public bool UpdateCell(Map map, UIManager uIManager, ItemManager itemManager, EntityManager entityManager)
        {
            turnBuildup += entity.spd.GetStat();

            while (turnBuildup >= GlobalVariables.actionThreshold)
            {
                //update UI for player
                if (entity == entityManager.GetPlayer())
                {
                    uIManager.DrawUI(map);
                }

                if (map.GetTile(map.GetEntityIndex(entityManager.GetPlayer())).GetExit())
                {
                    return true;
                }

                uIManager.AddEventToLog(TakeAction(map, uIManager, itemManager));

                //check if entity takes damage from tile
                if (map.GetTile(map.GetEntityIndex(entity)).GetDangerous())
                {
                    uIManager.AddEventToLog(map.GetTile(map.GetEntityIndex(entity)).DealDamage(entity));
                }

                entityManager.CheckDeadEntities(map, uIManager);
            }

            return false;
            
        }

        private string TakeAction(Map map, UIManager uIManager, ItemManager itemManager)
        {
            turnBuildup -= GlobalVariables.actionThreshold;
            return entity.ChooseAction(map, map.GetEntityIndex(entity), uIManager, itemManager);
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
        
        public EntityManager()
        {
            turnCells = new List<TurnCell>();
        }

        public void AddEntity(Entity entity)
        {
            if (entity == null)
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

        public bool UpdateEntities(Map map, UIManager uIManager, ItemManager itemManager)
        {
            for (int i = 0; i < turnCells.Count; i++)
            {
                if (turnCells[i].UpdateCell(map, uIManager, itemManager, this))
                {
                    return true;
                }
            }

            return false;
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

        public void CheckDeadEntities(Map map, UIManager uIManager)
        {
            for(int i=0; i<turnCells.Count; i++)
            {
                if (turnCells[i].entity.health.GetHp() <= 0)
                {
                    uIManager.AddEventToLog(turnCells[i].entity.GetName() + " died.");
                    map.RemoveEntity(turnCells[i].entity);
                    turnCells.Remove(turnCells[i]);
                }
            }
        }
       
    }
}
