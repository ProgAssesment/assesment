using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public interface IBrandRepository
    {
        List<Brand> GetAll();
        Brand Get(int id);
        Brand GetByName(String name);
        void Delete(int id);
        void Create(Brand brand);
        void Edit(Brand brand);

    }
}
