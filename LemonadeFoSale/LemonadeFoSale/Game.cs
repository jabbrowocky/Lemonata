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
        List<Customer> passersBy = new List<Customer>();
        


        //constructor
        public Game()
        {
            playerOne = new Player(25.00, new Inventory(new List<Lemon>(), new List<Sugar>(), new List<Cups>(), new List<IceCube>()));
            UI.DisplayTitleLoop(this);                   
            
        }

        //member methods

        public void RunGame(int days, string name)
        {
          
            TodaysWeather = new Weather();
            for (int i = 1; i <= NumberOfDays; i ++)
            {
                MainScreenDisplay();                
                NumberOfDays--;
            }
            
            
           

        }

        public int CreateCustomers()
        {
            int customerBase;
            if (TodaysWeather.TodaysWeatherType == "Rainy" || TodaysWeather.TodaysWeatherType == "Foggy")
            {
                customerBase = 25;
                
            }
            else if(TodaysWeather.TodaysTemp <= 65)
            {
                customerBase = 30;
                
            }
            else
            {
                customerBase = 50;
            }
            return customerBase;


        }
        public void PopulatePassersby(int customerBase)
        {
            for (int i = 0; i < customerBase; i ++)
            {
                passersBy.Add(new Customer());
            }
        }
        public void RunDay()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Beginning of Day " + this.dayNumber + "\n*****************************\n");
            Console.ResetColor();
            int pitcherInput = UI.GetUserIntegerInRange("How many pitchers would you like use? You have " + playerOne.playerRecipe.numberOfPitchers + " available", 1, playerOne.playerRecipe.numberOfPitchers);
            double userPrice = UI.GetUserDoubleInRange("At what price would you like to sell your cups of lemonade?", 0, 5);
            ConsumePitcher(pitcherInput, userPrice);
            Console.WriteLine("You have {0} cups available for purchase at {1} per cup", playerOne.playerRecipe.CupsToSell.Count, playerOne.playerRecipe.sellCup.standPrice);
            Console.ReadKey();        

           
            PopulatePassersby(CreateCustomers());
            for ( int i = 0; i < passersBy.Count; i++)
            {

            }

        }
        
        public void ConsumePitcher(int userInput, double sellPrice)
        {
            if (userInput > 1 && playerOne.playerStock.numberOfCups.Count < 21)
            {
                playerOne.playerRecipe.AddCups(playerOne, sellPrice);
                Console.WriteLine("You only had enough cups to use 1 pitcher you have {0} left", playerOne.playerRecipe.numberOfPitchers);
                return;
            }
            for (int i = 0; i < userInput; i ++)
            {
                
                playerOne.playerRecipe.AddCups(playerOne, sellPrice);
               

            }   
           
        }


        public void RunStore(Store store)
        {
            Console.Clear();            
            Console.Write("\n");
            store.DisplayStore(playerOne);
            OptionsNavigation(DisplayOptions("\nTo return to store, press 's' and to return to main screen press 'm'.", new List<string> { "m","s" }));
        }
        
        
        public string GetPlayerName()
        {
            Console.WriteLine("\n Please enter player name: \n");
            playerOne.playerName = Console.ReadLine();
            if (playerOne.playerName == "Donald Trump")
            {
                Console.Clear();
                Console.WriteLine("You've got a very good brain, your lemonade stand is bound to succeed\ngiven your massive understanding of business acumen, you win, so much winning.");
                Console.ReadKey();
                Environment.Exit(0);
            }
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
            Console.WriteLine(" Lemons: " + playerOne.playerStock.Lemons.Count);
            Console.WriteLine(" Cups of Sugar: " + playerOne.playerStock.cupsOfSugar.Count);
            Console.WriteLine(" Ice Cubes: " + playerOne.playerStock.numberOfCubes.Count);
            Console.WriteLine(" Paper Cups: " + playerOne.playerStock.numberOfCups.Count + "\n");
            if(!(playerOne.playerRecipe.previousRecipeIngredients.Count < 3))
            {
                playerOne.playerRecipe.DisplayPreviousRecipe();
            }
            DisplayRecipe();
            Console.WriteLine("\n Let's craft your lemonade recipe\n Note: makes 1 pitcher, which in turn makes up to 20 cups (or as many cups as you have available if < 20))\n");
            Console.WriteLine(" Press 'l' to add lemons, 's' to add sugar, 'i' to add ice cubes, 'm' to return to main menu, or 'f' to finalize recipe.");
            string userInput = Console.ReadLine();
            GetRecipeLogic(userInput, playerOne.playerRecipe);       
            
            
        }
        public void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Current Recipe Contains:\n***********************\n");
            Console.ResetColor();
            Console.WriteLine(" Lemons: " + playerOne.playerRecipe.lemonsPerPitcher);
            Console.WriteLine(" Sugar: " + playerOne.playerRecipe.sugarPerPitcher);
            Console.WriteLine(" Ice Cubes: " + playerOne.playerRecipe.cubesPerPitcher);
            Console.WriteLine(" Number of pitchers created: {0}", playerOne.playerRecipe.numberOfPitchers);
        }
        public void GetRecipeMenuLogic(int userChoice)
        {
            Lemon lemon = new Lemon();
            IceCube iceCube = new IceCube();
            
        }
        public void GetRecipeLogic(string userInput, Recipe recipe)
        {
            switch (userInput)
            {
                case "l":
                    SetLemons(UI.GetUserIntegerInRange("Please select how many lemons you wish to use per pitcher", 0, playerOne.playerStock.Lemons.Count));
                    Console.Clear();
                    SetLemonadeRecipe();
                    break;
                case "s":
                    SetSugar(UI.GetUserIntegerInRange("Please select how many cups of sugar you wish to use per pitcher", 0, playerOne.playerStock.cupsOfSugar.Count));
                    Console.Clear();
                    SetLemonadeRecipe();
                    break;
                case "i":
                    SetIceCubes(UI.GetUserIntegerInRange("Please select how many ice cubes you wish to use per pitcher", 0, playerOne.playerStock.numberOfCubes.Count));
                    Console.Clear();
                    SetLemonadeRecipe();
                    break;
                case "m":
                    Console.Clear();
                    MainScreenDisplay();
                    break;
                case "f":
                    playerOne.playerRecipe.CreatePitcher();
                    Console.Clear();                    
                    SetLemonadeRecipe();
                    break;
                default:
                    Console.WriteLine("That is not a valid input, please enter one of the options. Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    SetLemonadeRecipe();
                    break;

            }

        }
        public void SetLemons(int userSelection)
        {
            playerOne.playerRecipe.lemonsPerPitcher = userSelection;
            playerOne.playerRecipe.AddLemons(playerOne);

        }
        public void SetSugar(int userSelection)
        {
            playerOne.playerRecipe.sugarPerPitcher= userSelection;
            playerOne.playerRecipe.AddSugar(playerOne);
        }
        public void SetIceCubes(int userSelection)
        {
            playerOne.playerRecipe.cubesPerPitcher = userSelection;
            playerOne.playerRecipe.AddIceCubes(playerOne);
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
            if (playerOne.playerRecipe.numberOfPitchers >= 1)
            {
                Console.WriteLine("Number of available pitchers: " + playerOne.playerRecipe.numberOfPitchers);
            }
            Console.WriteLine("\nAvailable Funds: {0:C2}" , Math.Round(player.availableFunds,2));
            
            
        }
        public void MainScreenDisplay()
        {
            Console.Clear();
            DisplayDayInformation();
            DisplayPlayerInventory(playerOne);
           
            if (playerOne.playerRecipe.numberOfPitchers == 0)
            {
                OptionsNavigation(DisplayOptions("\nTo access store, press 's' or press 'r' to set your recipe.", new List<string> { "s", "r" }));
            }
            else
            {
                OptionsNavigation(DisplayOptions("\nTo access store press 's' or press 'r' to set your recipe, or press 'd' to begin the day.", new List<string> { "s", "r", "d" }));
            }

        }
        
        public void DisplayDayInformation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Day to Day information:\n****************************\n");
            Console.ResetColor();
            Console.WriteLine("Day number: " + dayNumber);
            Console.WriteLine("Today's weather : {0}", TodaysWeather.TodaysWeatherType);
            Console.WriteLine("Today's temperature: {0}°", TodaysWeather.TodaysTemp);
            TodaysWeather.DisplayTomorrowsForcast();
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
