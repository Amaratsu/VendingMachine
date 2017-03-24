using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class BeverageContext : DbContext
    {
        public DbSet<Beverage> Beverages { get; set; }
    }
}