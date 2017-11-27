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
        static public string userInput;
        static List<ConsoleColor> titleColors = new List<ConsoleColor>() { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Blue };

        //constructor



        //member methods

        static public void TitleLoop()
        {

            List<string> titleScroll = new List<string>() { };
            titleScroll.Add("   _      _____ ___  ___ _____  _   _   ___  ______  _____   ");
            titleScroll.Add(@"  | |    |  ___||  \/  ||  _  || \ | | / _ \ |  _  \|  ___| ");
            titleScroll.Add(@"  | |    | |__  | .  . || | | ||  \| |/ /_\ \| | | || |__   ");
            titleScroll.Add(@"  | |    |  __| | |\/| || | | || . \ ||  _  || | | ||  __|  ");
            titleScroll.Add(@"  | |____| |___ | |  | |\ \_/ /| |\  || | | || |/  /| |___  ");
            titleScroll.Add(@"  \_____/\____/ \_|  |_/ \___/ \_| \_/\_| |_/|___./ \____/  ");
            titleScroll.Add(@"                                                            ");
            titleScroll.Add(@"                       _____  _____   ___   _   _ ______    ");
            titleScroll.Add(@"                      /  ___||_   _| / _ \ | \ | ||  _  \   ");
            titleScroll.Add(@"                      \  `--.  | |  / /_\ \|  \| || | | |   ");
            titleScroll.Add(@"                       `--.  \ | |  |  _  || . \ || | | |   ");
            titleScroll.Add(@"                      /\__/  / | |  | | | || |\  || |/  /   ");
            titleScroll.Add(@"                      \____./  \_/  \_| |_/\_| \_/|___./    ");
            titleScroll.Add("                                                             ");
            titleScroll.Add("                                        an Erik White joint  ");
            titleScroll.Add("  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            musicplayer.MenuMusic();
            for (int j = 0; j <= titleScroll.Count() - 1; j++)
            {

                Console.ForegroundColor = TitleColorRandomizer();
                Console.WriteLine(titleScroll[j]);

                Console.ResetColor();
                System.Threading.Thread.Sleep(350);
            }


            System.Threading.Thread.Sleep(1100);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n                 Press Any Key To Continue\n");
            Console.ResetColor();

            Console.ReadKey(true);
            MainMenu();
            

        }

        static public ConsoleColor TitleColorRandomizer()
        {
            Random rndColor = new Random();
            return titleColors[rndColor.Next(0, 6)];
        }
        
        static public ConsoleColor FuckYouRick()
        {
            return ConsoleColor.Yellow;
        }

        static public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n Lemonade Stand Main Menu");
            Console.WriteLine(" ------------------------\n\n Rules:(enter 'r')");
            Console.WriteLine("\n Set Game Parameters: (enter 'o')");
            Console.WriteLine("\n Start Game: (enter 's')");
            Console.WriteLine("\n Quit Game: (enter 'q')");
            userInput = Console.ReadKey(true).KeyChar.ToString();
            switch (userInput)
            {
                case ("r"):
                    DisplayRules();
                    break;
                case ("o"):
                    break;
                case ("s"):
                    break;
                case ("q"):
                    break;
                default:
                    break;

            }
        }
        static public void DisplayRules()
        {

        }
        
        
        
    }
}
