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

        public void UpdateCell(Map map, UIManager uIManager, ItemManager itemManager, EntityManager entityManager)
        {
            turnBuildup += entity.spd.GetStat();

            while (turnBuildup >= GlobalVariables.actionThreshold)
            {
                //update UI for player
                if (entity.GetName() == "Player")
                {
                    uIManager.DrawUI(map);
                }

                uIManager.AddEventToLog(TakeAction(map, uIManager, itemManager));
                entityManager.CheckDeadEntities(map, uIManager);
            }
            
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

        public void UpdateEntities(Map map, UIManager uIManager, ItemManager itemManager)
        {
            for (int i = 0; i < turnCells.Count; i++)
            {

                turnCells[i].UpdateCell(map, uIManager, itemManager, this);
            }
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
