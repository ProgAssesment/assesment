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

        public void Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Edit(Product product)
        {
            context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Product GetByName(String name)
        {
            return context.Products.Where(x => x.Name.Equals(name)).First();
        }
    }
}
