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
        Product Create(Product product);
        Product Edit(Product product);
    }
}
