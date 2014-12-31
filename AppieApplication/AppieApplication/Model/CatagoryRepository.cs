﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class CatagoryRepository : ICatagoryRepository
    {

        private DBcontext context;

        public CatagoryRepository()
        {
            this.context = new DBcontext(); 
        }

        public List<Catagory> GetAll()
        {
            return context.Catagories.ToList();
        }

        public Catagory Get(int id)
        {
            throw new NotImplementedException();
        }

        public Catagory GetByName(String name)
        {
            return context.Catagories.Where(x => x.Name.Equals(name)).First();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Catagory catagory)
        {
            context.Catagories.Add(catagory);
            context.SaveChanges();
        }

        public void Edit(Catagory catagory)
        {
            throw new NotImplementedException();
        }
        
    }
}
