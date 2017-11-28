using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    public class Inventory
    {
        //member variables
        public List<Lemon> Lemons;
        public List<Sugar> cupsOfSugar;
        public List<Cup> numberOfCups;

        //constructor
        public Inventory(List<Lemon>Lemons, List<Sugar>cupsOfSugar, List<Cup> numberOfCups)
        {
            this.Lemons = Lemons;
            this.cupsOfSugar = cupsOfSugar;
            this.numberOfCups = numberOfCups;
        }

        //member methods
        
    }
}
