using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class BrandRepository : IBrandRepository
    {

        private DBcontext context;

        public BrandRepository()
        {
            context = new DBcontext();
        }

        public List<Brand> GetAll()
        {
            return context.Brands.ToList();
        }

        public Brand Get(int id)
        {
            throw new NotImplementedException();
        }

        public Brand GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();
        }

        public void Edit(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
