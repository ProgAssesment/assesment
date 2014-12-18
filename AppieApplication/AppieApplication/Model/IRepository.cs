using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public interface IRepository
    {
        List<Product> GetAll();
        Product Get(int id);
        void Delete(int id);
        Product Create(Product product);
        Product Edit(Product product);
    }
}
