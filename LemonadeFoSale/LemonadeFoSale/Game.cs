﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    public class Game
    {
        //member variables
        public Weather TodaysWeather;
        int dayNumber = 1;
        public int NumberOfDays;
        Player playerOne;
        


        //constructor
        public Game()
        {
            playerOne = new Player(25.00, new Inventory(new List<Lemon>(), new List<Sugar>(), new List<Cup>(), new List<IceCube>()));
            UI.DisplayTitleLoop(this);                   
            
        }

        //member methods

        public void RunGame(int days, string name)
        {
          
            TodaysWeather = new Weather();
            MainScreenDisplay();
            
           

        }
        
        public void RunStore(Store store)
        {
            Console.Clear();            
            Console.Write("\n");
            store.DisplayStore(playerOne);
            OptionsNavigation(DisplayOptions("To return to store, press 's' and to return to main screen press 'm'.", new List<string> { "m","s" }));
        }
        
        
        public string GetPlayerName()
        {
            Console.WriteLine("\n Please enter player name: \n");
            playerOne.playerName = Console.ReadLine();
            return playerOne.playerName;
            
        }
        public int SetNumberOfDays()
        {

            int numberOfDays;                      
            numberOfDays = int.Parse(UI.ValidateInput("\n Please set the number of days (7, 14, or 21)" , new List<string>() {"7","14","21" }));
            NumberOfDays = numberOfDays;
            
            return NumberOfDays;

           
        }
        public void SetLemonadeRecipe()
        {
           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n{0}'s Current Stock\n*****************************\n", playerOne.playerName);
            Console.ResetColor();
            Console.WriteLine("Lemons: " + playerOne.playerStock.Lemons.Count);
            Console.WriteLine("Cups of Sugar: " + playerOne.playerStock.cupsOfSugar.Count);
            Console.WriteLine("Paper Cups: " + playerOne.playerStock.numberOfCups.Count);
            Console.WriteLine("Ice Cubes: " + playerOne.playerStock.numberOfCubes.Count);
            Console.WriteLine("\n Let's craft your lemonade recipe");
            GetRecipeLogic(DisplayOptions(" Press 'l' to add lemons, 's' to add sugar, 'i' to add ice cubes, 'c' to select the number of cups 'f' to finalize recipe.", new List<string> { "l", "s", "i", "c","f" }), playerOne.playerRecipe);

            
        }
        public void GetRecipeLogic(string userInput, Recipe recipe)
        {
            switch (userInput)
            {
                case "l":
                    SetLemons();
                    break;
                case "s":
                    break;
                case "i":
                    break;
                case "c":
                    break;
                case "f":
                    break;
                default:
                    break;

            }

        }
        public void SetLemons()
        {
            playerOne.playerRecipe.lemonsPerPitcher = UI.GetUserIntegerInRange("Please select how many lemons you wish to use per pitcher", 0, playerOne.playerStock.Lemons.Count);
            playerOne.playerRecipe.AddLemons(playerOne);

        }
        public void SetSugar()
        {

        }


    public void DisplayPlayerInventory(Player player)
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n{0}'s Current Stock\n*****************************\n", player.playerName);
            Console.ResetColor();
            Console.WriteLine("Lemons: " + player.playerStock.Lemons.Count);
            Console.WriteLine("Cups of Sugar: " + player.playerStock.cupsOfSugar.Count);
            Console.WriteLine("Paper Cups: " + player.playerStock.numberOfCups.Count);
            Console.WriteLine("Ice Cubes: " + player.playerStock.numberOfCubes.Count);
            Console.WriteLine("\nAvailable Funds: {0:C2}" , Math.Round(player.availableFunds,2));
            
            
        }
        public void MainScreenDisplay()
        {
            Console.Clear();
            DisplayDayInformation();
            DisplayPlayerInventory(playerOne);
            if (playerOne.playerStock.cupsOfSugar.Count == 0 || playerOne.playerStock.numberOfCubes.Count == 0 || playerOne.playerStock.numberOfCups.Count == 0 ||playerOne.playerStock.Lemons.Count == 0)
            {
                OptionsNavigation(DisplayOptions("To access store, press 's'.", new List<string> { "s" }));
            }
            else if (playerOne.playerRecipe.numberOfCupsCreated == 0)
            {
                OptionsNavigation(DisplayOptions("To access store, press 's' or press 'r' to set your recipe.", new List<string> { "s", "r" }));
            }
            else
            {
                OptionsNavigation(DisplayOptions("To access store press 's' or press 'r' to set your recipe, or press 'd' to run the day.", new List<string> { "s", "r", "d" }));
            }

        }
        
        public void DisplayDayInformation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Day to Day information:\n****************************");
            Console.ResetColor();
            Console.WriteLine("Day number: " + dayNumber);
            Console.WriteLine("Today's weather : {0}", TodaysWeather.TodaysWeatherType);
            Console.WriteLine("Today's temperature: {0}°", TodaysWeather.TodaysTemp);
            TodaysWeather.DisplayTomorrowsForcast();
        }
        public void RunDay()
        {

        }
        
        
        public string DisplayOptions(string instructions, List<string>validInputs)
        {
            string userInput = UI.ValidateInput(instructions, validInputs);
            
            return userInput;
        }
        public void OptionsNavigation(string userInput)
        {
            switch (userInput)
            {
                case "m":
                    Console.Clear();
                    MainScreenDisplay();
                    break;
                case "s":
                    Console.Clear();
                    RunStore(new Store());
                    break;
                case "r":
                    Console.Clear();
                    SetLemonadeRecipe();
                    break;
                case "d":
                    RunDay();
                    break;               
                default:
                    break;

            }
        }
    }
}
