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

        public string UpdateCell(Map map, UIManager uIManager, ItemManager itemManager)
        {
            turnBuildup += entity.spd.GetStat();

            if (turnBuildup >= GlobalVariables.actionThreshold)
            {
                return TakeAction(map, uIManager, itemManager);
            }
            else
            {
                return null;
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
            foreach (TurnCell turnCell in turnCells)
            {
                CheckDeadEntities(map, uIManager);

                //update UI for player
                if (turnCell.entity.GetName() == "Player")
                {
                    uIManager.DrawUI(map);
                }

                uIManager.AddEventToLog(turnCell.UpdateCell(map, uIManager, itemManager));
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
            foreach (TurnCell turnCell in turnCells)
            {
                if (turnCell.entity.health.GetHp() <= 0)
                {
                    uIManager.AddEventToLog(turnCell.entity.GetName() + " died.");
                    map.RemoveEntity(turnCell.entity);
                    turnCells.Remove(turnCell);
                }
            }
        }
       
    }
}
