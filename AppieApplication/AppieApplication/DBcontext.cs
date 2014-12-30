using AppieApplication.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication
{
    public class DBcontext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<Catagory> Catagories { get; set; }

        public DbSet<Brand> Brands { get; set; }

    }
}
