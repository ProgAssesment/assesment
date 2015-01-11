using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public interface IDiscountRepository
    {
        List<Discount> GetAll();
        Discount Get(int id);
        void Delete(Discount discount);
        void Create(Discount discount);
        void Edit(Discount discount);
    }
}
