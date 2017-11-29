using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    public class Store
    {

        //member variables
        

        //constructor
        public Store()
        {
            
        }

        //member methods

        public void DisplayStore(Player player)
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Store Menu\n*************");
            Console.ResetColor();
            Console.Write("\n Purchase lemons: $0.25 per/lemon");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Press 'l'");
            Console.ResetColor();
            Console.Write("\n Purchase cups of sugar: $0.20 per/cup of sugar");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Press 's'");
            Console.ResetColor();
            Console.Write("\n Purchase paper cups: $0.15 per/paper cup");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Press 'p'");
            Console.ResetColor();
            Console.Write("\n Purchase ice cubes: $0.05 per/3 cubes");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Press 'c'");
            Console.ResetColor();
            Console.WriteLine("\nYou can also press 'm' for more options.");
            Console.WriteLine("\n-----------------------------------\n   Current Inventory\n");
            Console.WriteLine(" {0} Lemons", player.playerStock.Lemons.Count);
            Console.WriteLine(" {0} Cups of Sugar", player.playerStock.cupsOfSugar.Count);
            Console.WriteLine(" {0} Paper Cups", player.playerStock.numberOfCups.Count);
            Console.WriteLine(" {0} Ice Cubes", player.playerStock.numberOfCubes.Count);
            Console.WriteLine(" Available Income: {0:C2}", Math.Round(player.availableFunds,2));
            
            string userInput = Console.ReadLine();
            GetStoreLogic(userInput, player);
            
        }
        public void CheckMaximumLemonPurchase(int userInput, Player player)
        {

            Lemon lemon = new Lemon();
            if (player.availableFunds < (userInput * lemon.UnitPrice))
            {
                Console.WriteLine("You don't have enough money to purchase that amount\nPress any key to continue.");
                Console.ReadKey();
                GetStoreLogic("l", player);

            }
            else
            {
                PurchaseItems(userInput, PurchaseLemons, player);
            }
        }
        public void CheckMaximumSugarPurchase(int userInput, Player player)
        {
            Sugar sugar = new Sugar();
            if (player.availableFunds < (userInput * sugar.unitPrice))
            {
                Console.WriteLine("You don't have enough money to purchase that amount\nPress any key to continue.");
                Console.ReadKey();
                GetStoreLogic("s", player);
            }
            else
            {
                PurchaseItems(userInput, PurchaseSugar, player);
            }
        }
        public void CheckMaximumCupPurchase(int userInput, Player player)
        {
            Cup cup = new Cup();
            if (player.availableFunds < (userInput * cup.unitPrice))
            {
                Console.WriteLine("You don't have enough money to purchase that amount\nPress any key to continue.");
                Console.ReadKey();
                GetStoreLogic("p", player);
            }
            else
            {
                PurchaseItems(userInput, PurchaseCups, player);
            }
            
        }
        public void CheckMaximumCubePurchase(int userInput, Player player)
        {
            IceCube cube = new IceCube();
            if (player.availableFunds < (userInput * cube.iceUnitPrice))
            {
                Console.WriteLine("You don't have enough money to purchase that amount\nPress any key to continue.");
                Console.ReadKey();
                GetStoreLogic("c", player);
            }
            else
            {
                PurchaseItems(userInput, PurchaseCubes, player);
            }
        }
        public void GetStoreLogic(string userInput, Player player)
        {
            Console.Clear();
            switch (userInput)
            {
                case "l":
                    Console.WriteLine("Current Inventory\n-----------------------------------\n");
                    Console.WriteLine(" {0} Lemons", player.playerStock.Lemons.Count);
                    Console.WriteLine(" {0} Cups of Sugar", player.playerStock.cupsOfSugar.Count);
                    Console.WriteLine(" {0} Paper Cups", player.playerStock.numberOfCups.Count);
                    Console.WriteLine(" {0} Ice Cubes", player.playerStock.numberOfCubes.Count);
                    Console.WriteLine(" Available Income: {0:C2}\n", Math.Round(player.availableFunds, 2));
                    int userSelectionLemons = UI.GetUserIntegerInRange("Purchase how many lemons? enter a number.", 0 , 100 );                    
                    CheckMaximumLemonPurchase(userSelectionLemons, player);
                    Console.Clear();
                    DisplayStore(player);                    
                    break;
                case "s":
                    Console.WriteLine("Current Inventory\n-----------------------------------\n");
                    Console.WriteLine(" {0} Lemons", player.playerStock.Lemons.Count);
                    Console.WriteLine(" {0} Cups of Sugar", player.playerStock.cupsOfSugar.Count);
                    Console.WriteLine(" {0} Paper Cups", player.playerStock.numberOfCups.Count);
                    Console.WriteLine(" {0} Ice Cubes", player.playerStock.numberOfCubes.Count);
                    Console.WriteLine(" Available Income: {0:C2}\n", Math.Round(player.availableFunds, 2));
                    int userSelectionSugar = UI.GetUserIntegerInRange("Purchase how many cups of sugar? enter a number.", 0, 1000);                    
                    CheckMaximumSugarPurchase(userSelectionSugar, player);
                    Console.Clear();
                    DisplayStore(player);                    
                    break;
                case "p":
                    Console.WriteLine("Current Inventory\n-----------------------------------\n");
                    Console.WriteLine(" {0} Lemons", player.playerStock.Lemons.Count);
                    Console.WriteLine(" {0} Cups of Sugar", player.playerStock.cupsOfSugar.Count);
                    Console.WriteLine(" {0} Paper Cups", player.playerStock.numberOfCups.Count);
                    Console.WriteLine(" {0} Ice Cubes", player.playerStock.numberOfCubes.Count);
                    Console.WriteLine(" Available Income: {0:C2}\n", Math.Round(player.availableFunds, 2));
                    int userSelectionCups = UI.GetUserIntegerInRange("Purchase how many paper cups? enter a number.", 0, 500);                    
                    CheckMaximumCupPurchase(userSelectionCups, player);
                    Console.Clear();
                    DisplayStore(player);                    
                    break;
                case "c":
                    Console.WriteLine("Current Inventory\n-----------------------------------\n");
                    Console.WriteLine(" {0} Lemons", player.playerStock.Lemons.Count);
                    Console.WriteLine(" {0} Cups of Sugar", player.playerStock.cupsOfSugar.Count);
                    Console.WriteLine(" {0} Paper Cups", player.playerStock.numberOfCups.Count);
                    Console.WriteLine(" {0} Ice Cubes", player.playerStock.numberOfCubes.Count);
                    Console.WriteLine(" Available Income: {0:C2}\n", Math.Round(player.availableFunds, 2));
                    int userSelectionCubes = UI.GetUserIntegerInRange("Purchase how many ice cubes. Note: each purchase is 3 cubes", 0, 1000);
                    CheckMaximumCubePurchase(userSelectionCubes, player);
                    Console.Clear();
                    DisplayStore(player);
                    break;
                case "m":
                    Console.Clear();
                    break;              
                default:
                    Console.Clear();
                    DisplayStore(player);
                    break;
            }
        }
        public void PurchaseItems(int UserInput, Action<Player> callback, Player player)
        {
            for (int i = 0; i < UserInput; i++)
            {
                callback(player);
            }
        }
        public void PurchaseLemons(Player player)
        {
            Lemon lemon = new Lemon();
            player.playerStock.Lemons.Add(lemon);
            player.availableFunds = Math.Round((player.availableFunds - lemon.UnitPrice),2);
        }
        public void PurchaseSugar(Player player)
        {
            Sugar sugar = new Sugar();
            player.playerStock.cupsOfSugar.Add(sugar);
            player.availableFunds = Math.Round((player.availableFunds - sugar.unitPrice),2);
        }
        public void PurchaseCups(Player player)
        {
            Cup cup = new Cup();
            player.playerStock.numberOfCups.Add(cup);
            player.availableFunds = Math.Round((player.availableFunds - cup.unitPrice),2);
        }
        public void PurchaseCubes(Player player)
        {
            IceCube cubes = new IceCube();
            player.playerStock.numberOfCubes.Add(cubes);
            player.playerStock.numberOfCubes.Add(cubes);
            player.playerStock.numberOfCubes.Add(cubes);
            player.availableFunds = Math.Round((player.availableFunds - cubes.iceUnitPrice),2);
        }
    }
}
