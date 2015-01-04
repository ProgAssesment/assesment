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
            return context.Brands.Where(x => x.id.Equals(id)).First();
        }

        public Brand GetByName(String name)
        {
            return context.Brands.Where(x => x.Name.Equals(name)).First();
        }

        public void Delete(Brand brand)
        {
            context.Brands.Remove(brand);
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
