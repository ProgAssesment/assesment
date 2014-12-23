using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class ShoppingList
    {
        private List<Product> productList;

        public ShoppingList()
        {
            productList = new List<Product>();
        }

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
