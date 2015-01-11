using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Get(int id);
        void Delete(Product proudct);
        void Create(Product product);
        void Edit(Product product);
        Product GetByName(String name);
    }
}
