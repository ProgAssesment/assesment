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
        void Delete(int id);
        Catagory Create(Catagory catagory);
        Catagory Edit(Catagory catagory);

    }
}
