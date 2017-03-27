using System.Data.Entity;

namespace VendingMachine.Models
{
    public class BeverageContext : DbContext
    {
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Coin> Coins { get; set; }
    }
}