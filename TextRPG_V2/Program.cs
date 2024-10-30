using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Loading Settings
            string path = Path.Combine(Environment.CurrentDirectory, GlobalVariables.settingsDirectory, GlobalVariables.settingsFilename);

            if (!File.Exists(path))
            {
                Console.WriteLine("Setting file not found");
                Console.ReadKey();
                return;
            }

            string settingsText = File.ReadAllText(path);
            Settings settings = JsonSerializer.Deserialize<Settings>(settingsText);
            settings.ApplySettings();

            GameManager gameManager = new GameManager();
            gameManager.StartGame();
        }
    }
}
