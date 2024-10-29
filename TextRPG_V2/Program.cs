using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Loading Settings
            string path = Path.Combine(Environment.CurrentDirectory, GlobalVariables.settingsDirectory, GlobalVariables.settingsFilename);
            Settings settings = new Settings(path);
            settings.LoadSettings();

            GameManager gameManager = new GameManager();
            gameManager.StartGame();
        }
    }
}
