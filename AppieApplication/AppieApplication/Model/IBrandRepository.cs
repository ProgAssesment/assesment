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
        void Delete(Brand brand);
        void Create(Brand brand);
        void Edit(Brand brand);
        void AddToShoppingList(Brand brand);

        void AddToShoppingList(Brand brand);

    }
}
