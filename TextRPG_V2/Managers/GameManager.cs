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

        private bool gameWin;
        private bool gameLose;

        public GameManager() 
        {
            gameLose = false;
            gameWin = false;
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
            while (!gameLose && !gameWin)
            {
                entityManager.UpdateEntities(map, uiManager, itemManager);
                itemManager.UpdateItems();

                if(entityManager.GetPlayer() == null)
                {
                    gameLose=true;
                }
                else if (map.GetTile(map.GetEntityIndex(entityManager.GetPlayer())).GetExit())
                {
                    gameWin = true;
                }
            }

            FinishGame();
           
        }

        public void FinishGame()
        {
            Console.Clear();

            if (gameWin)
            {
                Console.WriteLine("You Win!!!");
            }
            else if (gameLose)
            {
                Console.WriteLine("You Lose...");
            }

            Console.ReadKey(true);
        }
    }
}
