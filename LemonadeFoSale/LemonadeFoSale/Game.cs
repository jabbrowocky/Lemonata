using System;
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
        int dayNumber;
        public int NumberOfDays;
        public double todaysExpenses;
        public double previousExpenses;
        public double todaysProfit;
        public double previousProfit;        
        Player playerOne;
        Random rnd = new Random();
        Store store = new Store();
       
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
            for (dayNumber = 1; dayNumber <= NumberOfDays; dayNumber++)
            {
                MainScreenDisplay();
                

            }
            
            
           

        }
        public void DailyReport()
        {
            GetDayResults();
            TrackExpenses();
            DisplayExpenses();            
            TrackProfit();
            DisplayProfit();
            Console.ReadKey();
        }
        public void TrackProfit()
        {
            todaysProfit = playerOne.playerRecipe.cupsSold * playerOne.playerRecipe.sellCup.standPrice;
        }
        public void GetDayResults()
        {
            Console.WriteLine("Out of {0} potential customers {1} purchased lemonade.", passersBy.Count, playerOne.playerRecipe.cupsSold);
            passersBy.Clear();
        }
        public void DisplayProfit()
        {

            Console.WriteLine("You sold {0} cups for a total of {1:C2}", playerOne.playerRecipe.cupsSold, (todaysProfit));
            
        }
        public void TrackExpenses()
        {
            Sugar purchasedSugar = new Sugar();
            IceCube purchasedIce = new IceCube();
            Cups purchasedCups = new Cups();
            Lemon purchasedLemons = new Lemon();

            todaysExpenses = (playerOne.icePurchased * purchasedIce.iceUnitPrice)+(playerOne.lemonsPurchased * purchasedLemons.UnitPrice)+(playerOne.cupsPurchased * purchasedCups.UnitPrice) + (playerOne.sugarPurchased * purchasedSugar.unitPrice);
        }
        public void DisplayExpenses()
        {
            Console.WriteLine("Today's expenses: {0:C2}", todaysExpenses);
        }
        public void SetYesterdaysExpenses()
        {

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
        public void MakesPurchase()
        {
            foreach(Customer potentialCustomer in passersBy)
            {
                if (playerOne.playerRecipe.CupsToSell.Count > 0)
                {
                    if (potentialCustomer.willBuy == true)
                    {
                        playerOne.playerRecipe.CupsToSell.RemoveAt(0);
                        playerOne.playerRecipe.cupsSold++;
                        playerOne.availableFunds += playerOne.playerRecipe.sellCup.standPrice;
                    }
                }
                else
                {
                    Console.WriteLine("You ran out of cups to sell.");
                    
                }
                
            }
            Console.ReadKey();
        }

        public void PopulatePassersby(int customerBase)
        {
            for (int i = 0; i < customerBase; i ++)
            {
                Customer potentialCustomer = new Customer(playerOne, rnd);
                                              
                passersBy.Add(potentialCustomer);
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
            Console.WriteLine("You have {0} cups available for purchase at {1:C2} per cup, press any key to start day.", playerOne.playerRecipe.CupsToSell.Count, playerOne.playerRecipe.sellCup.standPrice);
            Console.ReadKey();



            PopulatePassersby(CreateCustomers());
            MakesPurchase();
            DailyReport();
            playerOne.playerRecipe.CupsToSell.Clear();
            

        }
        //public void WillBuyCheck()
        //{
        //    foreach (Customer potentialCustomer in passersBy)
        //    {
        //        if (potentialCustomer.willBuy == true)
        //        {
        //            Console.WriteLine("a customer made a purchase");
        //            Console.ReadKey();
        //        }

        //    }
        //}
        
        public void ConsumePitcher(int userInput, double sellPrice)
        {
            if (userInput >= 1 && playerOne.playerStock.numberOfCups.Count < 21)
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


        public void RunStore()
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
            numberOfDays = int.Parse(UI.ValidateInput("\n Please set the number of days you'd like to play for. (7, 14, or 21)" , new List<string>() {"7","14","21" }));
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
                OptionsNavigation(DisplayOptions("\nTo access store, press 's' or press 'r' to set your recipe menu.", new List<string> { "s", "r" }));
            }
            else
            {
                Console.WriteLine("Press 's' to buy more supplies, press 'r' to access your recipe menu");
                Console.WriteLine("       or press 'd' to begin the day");
                string userInput = Console.ReadLine();
                OptionsNavigation(userInput);
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
                    RunStore();
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
