using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class ProductRepository : IProductRepository
    {

        private DBcontext context;

        public ProductRepository()
        {
            context = new DBcontext();
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product Get(int id)
        {
            return context.Products.Where(x => x.Id.Equals(id)).First();
        }

        public void Delete(Product product)
        {

            List<Brand> brands = context.Brands.Where(x => x.ProductId.Equals(product.Id)).ToList();

            context.Products.Remove(product);

            foreach (Brand b in brands)
            {
                context.Brands.Remove(b);
            }

            context.SaveChanges();

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
