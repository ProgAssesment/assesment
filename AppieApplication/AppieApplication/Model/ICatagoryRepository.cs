using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public interface ICatagoryRepository
    {
        List<Catagory> GetAll();
        Catagory Get(int id);
        Catagory GetByName(String name);
        void Delete(Catagory catagory);
        void Create(Catagory catagory);
        void Edit(Catagory catagory);

    }
}
