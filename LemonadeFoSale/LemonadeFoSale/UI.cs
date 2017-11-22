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
        
        static List<ConsoleColor> titleColors = new List<ConsoleColor>() {ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Blue};
        static Random rndColor;
        //constructor


        //member methods
        static public void DisplayTitleArt()
        {
            Console.ForegroundColor = TitleColorRandomizer();
            Console.WriteLine("   _      _____ ___  ___ _____  _   _   ___  ______  _____  ");
            Console.WriteLine(@"  | |    |  ___||  \/  ||  _  || \ | | / _ \ |  _  \|  ___| ");
            Console.WriteLine(@"  | |    | |__  | .  . || | | ||  \| |/ /_\ \| | | || |__   ");
            Console.WriteLine(@"  | |    |  __| | |\/| || | | || . \ ||  _  || | | ||  __|  ");
            Console.WriteLine(@"  | |____| |___ | |  | |\ \_/ /| |\  || | | || |/ / | |___  ");
            Console.WriteLine(@"  \_____/\____/ \_|  |_/ \___/ \_| \_/\_| |_/|___/  \____/  ");
            Console.WriteLine(@"                                                          ");
            Console.WriteLine(@"                                                          ");
            Console.WriteLine(@"                       _____  _____   ___   _   _ ______  ");
            Console.WriteLine(@"                      /  ___||_   _| / _ \ | \ | ||  _  \ ");
            Console.WriteLine(@"                      \  `--.  | |  / /_\ \|  \| || | | | ");
            Console.WriteLine(@"                       `--.  \ | |  |  _  || . \ || | | | ");
            Console.WriteLine(@"                      /\__/  / | |  | | | || |\  || |/  /  ");
            Console.WriteLine(@"                      \____./  \_/  \_| |_/\_| \_/|___./   ");
            Console.WriteLine("                                                            ");
            Console.WriteLine("  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ResetColor();
            Console.WriteLine("         Press any key to continue.");
            Console.ReadKey();


        }

        static public ConsoleColor TitleColorRandomizer()
        {
            Random rndColor = new Random();
            return titleColors[rndColor.Next(7)];
        }
    }
}
