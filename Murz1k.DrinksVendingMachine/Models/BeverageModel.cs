using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Murz1k.DrinksVendingMachine.Models
{
    public class Beverage
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }
    }

    public class Coin
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public int Count { get; set; }

        public bool IsLocked { get; set; }
    }

    public class DrinksVendingContext : DbContext
    {
        public DrinksVendingContext() :
        //base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DrinksDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        base(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DrinksDB.mdf;Database=DrinkDB;Trusted_Connection=Yes;")
        {
            

        }

        public DbSet<Beverage> Beverages { get; set; }

        public DbSet<Coin> Coins { get; set; }
    }
}