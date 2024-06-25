using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();

            //Title
            Console.WriteLine("          Welcome To:          \n");

            Console.WriteLine("  ___   _____   ____           ");
            Console.WriteLine(" / _ \\  \\   /  /  _ \\  |\\    /|");
            Console.WriteLine("/./ \\.\\  \\./  /../ \\.\\ |.\\  /.|");
            Console.WriteLine("|.|  |.| |.|  \\..\\  |/ |.|__|.|");
            Console.WriteLine("|:|  |/  |:|   \\::\\    |::::::|");
            Console.WriteLine("|:| ___  |:|    \\::\\   |:|  |:|");
            Console.WriteLine("|x| \\x/  |x|     \\xx\\  |x|  |x|");
            Console.WriteLine("|x| |x|  |x|      |xx| |x|  |x|");
            Console.WriteLine("\\X\\_/X|  /X\\  |\\_/XX/  |X|  |X|");
            Console.WriteLine(" \\XXXX| /XXX\\ |XXXX/   |X|  |X|");
            Console.WriteLine("___ |X| _____ |X| ____ |X|  |X|");
            Console.WriteLine("|XX |X| |XXXX |X| |XXX |X/  \\X|");
            Console.WriteLine("    |/        |/       |/    \\|");

            //Description
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("You are a Gish warrior; practitioner of");
            Console.WriteLine("both might and magic. You have been trapped");
            Console.WriteLine("in an ancient dungeon. Can you use your wits");
            Console.WriteLine("to escape?");

            //user prompt
            Console.WriteLine("\nPress any key to start the game...");

            //start sequence
            Console.ReadKey(true);
            Console.Clear();
            gameManager.StartGame();
        }
    }
}
