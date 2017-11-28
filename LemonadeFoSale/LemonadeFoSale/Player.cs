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

        //constructor
        public Player(double availableFunds, Inventory playerStock)
        {
            this.availableFunds = availableFunds;
            this.playerStock = playerStock;
        }

        //member methods
        

    }
}
