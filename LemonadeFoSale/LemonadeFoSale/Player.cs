using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    public class Player
    {
        //member variables
        public string playerName;
        public Inventory playerStock;
        public double availableFunds;
        public Recipe playerRecipe;
        public int lemonsPurchased;
        public int cupsPurchased;
        public int sugarPurchased;
        public int icePurchased;

        //constructor
        public Player(double availableFunds, Inventory playerStock)
        {
            playerRecipe = new Recipe();
            this.availableFunds = availableFunds;
            this.playerStock = playerStock;
        }

        //member methods
        

    }
}
