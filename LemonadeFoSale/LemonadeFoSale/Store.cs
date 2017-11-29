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
            Console.WriteLine("\n Purchase lemons: Press 'l'");
            Console.WriteLine("\n Purchase cups of sugar: Press 's'");
            Console.WriteLine("\n Purchase paper cups Press 'p'");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" {0} Lemons", player.playerStock.Lemons.Count);
            Console.WriteLine(" {0} Cups of Sugar", player.playerStock.cupsOfSugar.Count);
            Console.WriteLine(" {0} Paper Cups", player.playerStock.numberOfCups.Count);
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
                PurchaseItems(userInput, PurchaseSugar, player);
            }
            
        }
        public void GetStoreLogic(string userInput, Player player)
        {
            Console.Clear();
            switch (userInput)
            {
                case "l":                    
                    int userSelectionLemons = UI.GetUserIntegerInRange("Purchase how many lemons? enter a number.", 0 , 100 );
                    CheckMaximumLemonPurchase(userSelectionLemons, player);
                    
                    break;
                case "s":                    
                    int userSelectionSugar = UI.GetUserIntegerInRange("Purchase how many cups of sugar? enter a number.", 0, 1000);
                    CheckMaximumSugarPurchase(userSelectionSugar, player);
                    
                    break;
                case "p":
                    int userSelectionCups = UI.GetUserIntegerInRange("Purchase how many paper cups? enter a number.", 0, 500);
                    CheckMaximumCupPurchase(userSelectionCups, player);
                    
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
    }
}
