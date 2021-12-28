using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string mob { get; set; }
    }

    public class CustomerContext: DbContext
    {
        public DbSet<Customer> customer { get; set; }
        public DbSet<Inventory> inventory { get; set; }
        public DbSet<Sale> sale { get; set; }
        public DbSet<DiscountScheme> discountScheme { get; set; }

        public System.Data.Entity.DbSet<MVCExample.Models.Product> Products { get; set; }
        public DbSet<Course> course { get; set; }
    }
}