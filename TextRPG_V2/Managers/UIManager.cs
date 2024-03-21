using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public class UIManager
    {
        private Camera gameplayWindow;
        private StatWindow playerStatWindow;
        private StatWindow enemyStatWindow;
        private ControlsWindow controlsWindow;
        private EventLog eventLogWindow;

        private int[] gameplayPos;
        private int[] playerWinPos;
        private int[] enemyWinPos;
        private int[] controlsPos;
        private int[] eventLogPos;

        public UIManager(EntityManager entityManager)
        {

            //Instantiate all windows
            gameplayWindow = new Camera(entityManager.GetPlayer());
            playerStatWindow = new StatWindow(entityManager.GetPlayer());
            enemyStatWindow = new StatWindow(null);
            controlsWindow = new ControlsWindow();
            eventLogWindow = new EventLog();

            //set initial positions of windows
            gameplayPos = new int[2] { 0, 0 };
            playerWinPos = new int[2] { 0, gameplayWindow.GetWidth() + GlobalVariables.windowPadding };
            enemyWinPos = new int[2] { playerStatWindow.GetHeight() + GlobalVariables.windowPadding, gameplayWindow.GetWidth() + GlobalVariables.windowPadding };
            controlsPos = new int[2] { 0, gameplayWindow.GetWidth() + playerStatWindow.GetWidth() + 2 * GlobalVariables.windowPadding };
            eventLogPos = new int[2] { gameplayWindow.GetHeight(), 0 };

            int totalWidth = gameplayWindow.GetWidth() + playerStatWindow.GetWidth() + controlsWindow.GetWidth() + GlobalVariables.windowPadding * 2;
            int totalHeight = gameplayWindow.GetHeight() + eventLogWindow.GetHeight() + GlobalVariables.windowPadding * 2;

            //Setting console window size and settings
            Console.SetWindowSize(totalWidth, totalHeight);
            Console.SetBufferSize(totalWidth, totalHeight);
            Console.CursorVisible = false;
        }

        public void DrawUI(Map map)
        {
            gameplayWindow.DrawGamePlay(map, gameplayPos[0], gameplayPos[1]);
            playerStatWindow.printWindow(playerWinPos);
            enemyStatWindow.printWindow(enemyWinPos);
            controlsWindow.printWindow(controlsPos);
            eventLogWindow.printWindow(eventLogPos);
        }

        public void AddEventToLog(string eventMessage)
        {
            eventLogWindow.AddEvent(eventMessage);
        }

        public void SetEnemyStats(Entity target)
        {
            enemyStatWindow.ChangeTarget(target);
        }


    }
}
