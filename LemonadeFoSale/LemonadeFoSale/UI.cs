using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    static class UI
    {
        //member variables
        static string userInput;
        static List<ConsoleColor> titleColors = new List<ConsoleColor>() { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Blue };

        //constructor


        //member methods
        static public void DisplayTitleArt()
        {

            Console.ForegroundColor = TitleColorRandomizer();
            Console.WriteLine("   _      _____ ___  ___ _____  _   _   ___  ______  _____   ");
            Console.WriteLine(@"  | |    |  ___||  \/  ||  _  || \ | | / _ \ |  _  \|  ___| ");
            Console.ResetColor();
            System.Threading.Thread.Sleep(500);
            Console.ForegroundColor = TitleColorRandomizer();
            Console.WriteLine(@"  | |    | |__  | .  . || | | ||  \| |/ /_\ \| | | || |__   ");
            Console.ResetColor();
            System.Threading.Thread.Sleep(500);
            Console.ForegroundColor = TitleColorRandomizer();
            Console.WriteLine(@"  | |    |  __| | |\/| || | | || . \ ||  _  || | | ||  __|  ");
            Console.WriteLine(@"  | |____| |___ | |  | |\ \_/ /| |\  || | | || |/  /| |___  ");
            Console.ResetColor();
            System.Threading.Thread.Sleep(500);
            Console.ForegroundColor = TitleColorRandomizer();
            Console.WriteLine(@"  \_____/\____/ \_|  |_/ \___/ \_| \_/\_| |_/|___./ \____/  ");
            Console.WriteLine(@"                                                          ");
            Console.WriteLine(@"                                                          ");
            Console.ResetColor();
            System.Threading.Thread.Sleep(500);
            Console.ForegroundColor = TitleColorRandomizer();
            Console.WriteLine(@"                       _____  _____   ___   _   _ ______  ");
            Console.WriteLine(@"                      /  ___||_   _| / _ \ | \ | ||  _  \ ");
            Console.WriteLine(@"                      \  `--.  | |  / /_\ \|  \| || | | | ");
            Console.ResetColor();
            System.Threading.Thread.Sleep(500);
            Console.ForegroundColor = TitleColorRandomizer();
            Console.WriteLine(@"                       `--.  \ | |  |  _  || . \ || | | | ");
            Console.WriteLine(@"                      /\__/  / | |  | | | || |\  || |/  /  ");
            Console.ResetColor();
            System.Threading.Thread.Sleep(500);
            Console.ForegroundColor = TitleColorRandomizer();
            Console.WriteLine(@"                      \____./  \_/  \_| |_/\_| \_/|___./   ");
            Console.WriteLine("                                                            ");
            Console.ResetColor();
            System.Threading.Thread.Sleep(500);
            Console.ForegroundColor = TitleColorRandomizer();
            Console.WriteLine("                                         an Erik White joint  ");
            Console.WriteLine("  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1500);
            Console.WriteLine("\n         Press any key to continue.");
            userInput = Console.ReadKey(true).KeyChar.ToString();


        }

        static public ConsoleColor TitleColorRandomizer()
        {
            Random rndColor = new Random();
            return titleColors[rndColor.Next(0,6)];
        }
        static public void MainMenuDisplay()
        {

        }
    }
}
