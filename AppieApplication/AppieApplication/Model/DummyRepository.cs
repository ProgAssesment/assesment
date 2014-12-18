using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class DummyRepository : IRepository
    {
        public List<Product> GetAll()
        {
            var products = new List<Product>();

            products.Add(new Product { Id = 1, Brand = "Calve", Name = "Pindakaas", Price = 2.50, Type = "Broodbeleg" });
            products.Add(new Product { Id = 2, Brand = "De Ruijter", Name = "Hagelslag", Price = 3.00, Type = "Broodbeleg" });
            products.Add(new Product { Id = 3, Brand = "Albert Heijn", Name = "Kaas", Price = 1.00, Type = "Zuivel" });

            return products;

        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Edit(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
