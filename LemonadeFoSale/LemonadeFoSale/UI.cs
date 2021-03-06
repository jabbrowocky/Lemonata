﻿using System;
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

        public static void DisplayTitleLoop(Game game)
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
            for (int j = 0; j < titleScroll.Count(); j++)
            {

                Console.ForegroundColor = TitleColorRandomizer(game.rnd);
                Console.WriteLine(titleScroll[j]);

                Console.ResetColor();
                System.Threading.Thread.Sleep(350);
            }


            System.Threading.Thread.Sleep(550);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n                 Press Any Key To Continue\n");
            Console.ResetColor();

            Console.ReadKey(true);
            musicplayer.StopMenuMusic(new System.Media.SoundPlayer());
            DisplayMainMenu(game);
            
            

        }

        static public ConsoleColor TitleColorRandomizer(Random rnd)
        {
            
            return titleColors[rnd.Next(0, 6)];
        }
        
        
        static public void DisplayMainMenu(Game game)
        {
            Console.Clear();
            Console.WriteLine("\n\n Lemonade Stand Main Menu");
            Console.WriteLine(" ------------------------\n\n Rules:(enter 'r')");
            Console.WriteLine("\n Start Game: (enter 's')");
            Console.WriteLine("\n Quit Game: (enter 'q')");
            userInput = GetUserInput();
            MainMenuLogic(game, userInput);

            
            
        }
        static public void MainMenuLogic(Game game, string userInput)
        {
            switch (userInput)
            {
                
                case ("r"):
                    DisplayRules(game);
                    break;                
                case ("s"):
                    Console.Clear();
                    game.RunGame(game.SetNumberOfDays(), game.GetPlayerName());
                    break;
                case ("q"):
                    break;
                default:
                    Console.WriteLine("That is not a valid input.");
                    DisplayMainMenu(game);
                    break;

            }
        }
        static public string GetUserInput()
        {
            return Console.ReadLine();
        }

        static public void DisplayRules(Game game)
        {
            Console.Clear();
            Console.WriteLine("The rules are fairly simple:\n\n 1: Run your lemonade stand as you choose.\n 2: Play for 7, 14, or 21 'days'.\n 3: Purchase your inventory; cups, sugar, lemons.\n 4: See if you can turn a profit.\n Note: Weather will affect your client base, as will the mixture of your lemonade and the price.");
            Console.WriteLine("\n Please press any key to return to main menu.");
            Console.ReadKey(true);
            DisplayMainMenu(game);
        }


        static public string ValidateInput(string instruction, List<string> validInput)
        {
            Console.WriteLine(instruction);
            userInput = Console.ReadLine();
            if (!validInput.Contains(userInput))
            {
                Console.WriteLine("That is not a valid input, please enter a valid input.");
                Console.Clear();
                ValidateInput(instruction, validInput);
                
            }
            return userInput;
        }
        public static int GetUserIntegerInRange(string instruction, int min, int max)
        {
            Console.WriteLine(instruction);
            string userSelection = Console.ReadLine();
            int userSelectionNumber;
            if (!int.TryParse(userSelection, out userSelectionNumber) || !(userSelectionNumber >= min) || !(userSelectionNumber <= max))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, that is not a valid number. Please enter a number between {0} and {1}.", min, max);
                Console.ResetColor();
                return GetUserIntegerInRange(instruction, min, max);
            }
            else
            {
                return userSelectionNumber;
            }
        }
        public static double GetUserDoubleInRange(string instruction, double min, double max)
        {
            Console.WriteLine(instruction);
            string userSelection = Console.ReadLine();
            double userSelectionNumber;
            if (!double.TryParse(userSelection, out userSelectionNumber) || !(userSelectionNumber >= min) || !(userSelectionNumber <= max))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, that is not a valid number. Please enter a number between {0} and {1}.", min, max);
                Console.ResetColor();
                return GetUserDoubleInRange(instruction, min, max);
            }
            else
            {
                return userSelectionNumber;
            }
        }

    }
}
