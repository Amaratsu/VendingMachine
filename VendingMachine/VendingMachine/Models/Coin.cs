using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public int NumberOfCoins1 { get; set; }
        public int NumberOfCoins2 { get; set; }
        public int NumberOfCoins5 { get; set; }
        public int NumberOfCoins10 { get; set; }

        public int TheSumOfCoins1()
        {
            return NumberOfCoins1 * 1;
        }
        public int TheSumOfCoins2()
        {
            return NumberOfCoins2 * 2;
        }
        public int TheSumOfCoins5()
        {
            return NumberOfCoins5 * 5;
        }
        public int TheSumOfCoins10()
        {
            return NumberOfCoins10 * 10;
        }

        public int TotalAmountOfCoins()
        {
            return (NumberOfCoins1 * 1)
                   + (NumberOfCoins2 * 2)
                   + (NumberOfCoins5 * 5)
                   + (NumberOfCoins10 * 10);
        }
    }
}