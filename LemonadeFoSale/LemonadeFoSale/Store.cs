using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    class Store
    {

        //member variables
        

        //constructor
        public Store()
        {
            
        }

        //member methods

        public void DisplayStore()
        {
            Console.WriteLine("Welcome to the store");
            Console.WriteLine("\n Purchase lemons: Press 'l'");
            Console.WriteLine("\n Purchase cups of sugar: Press 's'");
            Console.WriteLine("\n Purchase paper cups Press 'p'");
        }
        public void StoreLogic()
        {

        }
        public void PurchaseLemons(Player player, Lemon lemon)
        {
            player.playerStock.Lemons.Add(new Lemon());
            player.availableFunds -= lemon.UnitPrice;
        }
        public void PurchaseSugar(Player player, Sugar sugar)
        {
            player.playerStock.cupsOfSugar.Add(new Sugar());
            player.availableFunds -= sugar.unitPrice;
        }
        public void PurchaseCups(Player player, Cup cups)
        {
            player.playerStock.numberOfCups.Add(new Cup());
            player.availableFunds -= cups.unitPrice;
        }
    }
}
