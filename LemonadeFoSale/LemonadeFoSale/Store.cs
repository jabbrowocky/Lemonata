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
            Console.WriteLine("Welcome to the store");
            Console.WriteLine("\n Purchase lemons: Press 'l'");
            Console.WriteLine("\n Purchase cups of sugar: Press 's'");
            Console.WriteLine("\n Purchase paper cups Press 'p'");
            Console.WriteLine("Available Income: " + "$" + player.availableFunds);
            string userInput = Console.ReadLine();
            GetStoreLogic(userInput, player);
            
        }
        public void GetStoreLogic(string userInput, Player player)
        {
            switch (userInput)
            {
                case "l":
                    Console.WriteLine("Purchase how many lemons? enter a number.");
                    
                    int userSelection = int.Parse(Console.ReadLine());
                    PurchaseItems(userSelection, PurchaseLemons, player);
                    break;
                case "s":
                    Console.WriteLine("Purchase how many cups of sugar?");
                    break;
                case "p":
                    Console.WriteLine("Purchase how many paper cups?");
                    break;
                default:
                    Console.Clear();
                    DisplayStore(player);
                    break;
            }
        }
        public void PurchaseItems(int UserInput, Action<Player> callback, Player player)
        {
            for (int i = 0; i <= UserInput; i++)
            {
                callback(player);
            }
        }
        public void PurchaseLemons(Player player)
        {
            Lemon lemon = new Lemon();
            player.playerStock.Lemons.Add(lemon);
            player.availableFunds -= lemon.UnitPrice;
        }
        public void PurchaseSugar(Player player)
        {
            Sugar sugar = new Sugar();
            player.playerStock.cupsOfSugar.Add(sugar);
            player.availableFunds -= sugar.unitPrice;
        }
        public void PurchaseCups(Player player)
        {
            Cup cup = new Cup();
            player.playerStock.numberOfCups.Add(cup);
            player.availableFunds -= cup.unitPrice;
        }
    }
}
