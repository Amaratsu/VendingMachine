using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VendingMachine.Models
{
    public class Coin
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int NumberOfCoins1 { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int NumberOfCoins2 { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int NumberOfCoins5 { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int NumberOfCoins10 { get; set; }
    }
}