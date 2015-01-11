using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    class DiscountRepository : IDiscountRepository
    {

        private DBcontext context;

        public DiscountRepository()
        {
            context = new DBcontext();
        }

        public List<Discount> GetAll()
        {
            return context.Discounts.ToList();
        }

        public Discount Get(int id)
        {
            return context.Discounts.Where(x => x.Coupon.Equals(id)).First();
        }

        public void Delete(Discount discount)
        {
            context.Discounts.Remove(discount);
            context.SaveChanges();
        }

        public void Create(Discount discount)
        {
            context.Discounts.Add(discount);
            context.SaveChanges();
        }

        public void Edit(Discount discount)
        {
            context.Entry(discount).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
