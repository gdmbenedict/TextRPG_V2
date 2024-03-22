using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public class GameManager
    {
        Map map;
        UIManager uiManager;
        EntityManager entityManager;
        ItemManager itemManager;

        public GameManager() 
        {
        
        }

        public void StartGame()
        {
            string path = Path.Combine(Environment.CurrentDirectory, GlobalVariables.directory, GlobalVariables.filename);

            entityManager = new EntityManager();
            itemManager = new ItemManager();

            map = new Map(path, entityManager, itemManager);

            uiManager = new UIManager(entityManager);
            uiManager.DrawUI(map);

            GameLoop();
        }

        public void GameLoop()
        {
            while (true)
            {
                entityManager.UpdateEntities(map, uiManager, itemManager);
                itemManager.UpdateItems();
            }

        }
    }
}
