using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    class Customer
    {
        //member variables
        public bool willBuy;
        Random customerParameters;

        //constructor
        public Customer(Player player, Random rnd)
        {
            customerParameters = rnd;
            int buyingCustomer;
            if (player.playerRecipe.sellCup.standPrice < .40)
            {
               buyingCustomer=customerParameters.Next(0, 100);
                if (buyingCustomer % 2 == 0)
                {
                    WillBuy();
                }
            }
             
        }

        public bool WillBuy()
        {
            return willBuy = true;
        }
        //member methods
    //    public bool WillBuy(Player player)
    //    {
    //        int result;
    //        customerParameters = new Random();
    //        if (player.playerRecipe.sellCup.standPrice <= 0.50)
    //        {                
    //            result = customerParameters.Next(0, 40);
    //            if ((result % 2 == 0) && (result % 3 == 0))
    //            {
    //                if (player.playerRecipe.CupsToSell.Count >= 1)
    //                {
    //                    player.playerRecipe.CupsToSell.RemoveAt(0);
    //                    player.playerRecipe.cupsSold++;
    //                    return true;
    //                }
    //                else
    //                {
    //                    Console.WriteLine("You ran out of cups.");
    //                    return false;
    //                }

    //            }
    //            else if (result % 2 == 0)
    //            {
    //                return false;
    //            }
    //            else
    //            {
    //                player.playerRecipe.CupsToSell.RemoveAt(0);
    //                player.playerRecipe.cupsSold++;
    //                return true;
    //            }
    //        }
    //        else
    //        {
    //            result = customerParameters.Next(0,100);
    //            if ((result % 2 == 0) && (result % 3 == 0))
    //            {
                    
    //                return false;
    //            }
    //            else if (result % 2 == 0)
    //            {
    //                return false;
    //            }
    //            else
    //            {
    //                player.playerRecipe.CupsToSell.RemoveAt(0);
    //                player.playerRecipe.cupsSold++;
    //                return true;
    //            }
    //        }
            
    //    }

    }
}
