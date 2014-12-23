using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class Recipe
    {
        private List<Product> productList;

        public Recipe()
        {
            productList = new List<Product>();
        }

        public string Name { get; set; }
        public string Merk { get; set; }

        public void AddProduct(Product product)
        {
            productList.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            productList.Remove(product);
        }



    }
}
