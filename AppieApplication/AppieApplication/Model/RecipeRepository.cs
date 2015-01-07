﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class RecipeRepository : IRecipeRepository
    {

        private DBcontext context;

        public RecipeRepository()
        {
            this.context = new DBcontext();
        }

        public List<Recipe> GetAll()
        {
            return context.Recipes.ToList();
        }

        public Recipe Get(int id)
        {
            return context.Recipes.Where(x => x.id.Equals(id)).First();
        }

        public Recipe GetByName(String name)
        {
            return context.Recipes.Where(x => x.Name.Equals(name)).First();
        }

        public void Delete(Recipe recipe)
        {


            List<Recipe> recipes = context.Recipes.Where(x => x.id.Equals(recipe.id)).ToList();

            List<Brand> brands = context.Brands.Where(x => x.Recipes.Equals(recipe.id)).ToList();

            foreach (Brand p in brands)
            {
                context.Brands.Remove(p);
            }


            context.Recipes.Remove(recipe);
            context.SaveChanges();
        }

        public void Create(Recipe recipe)
        {
            context.Recipes.Add(recipe);
            context.SaveChanges();
        }

        public void Edit(Recipe recipe)
        {
            Recipe recipes = context.Recipes.SingleOrDefault(b => b.id == recipe.id);
            recipes.Name = recipe.Name;
            recipes.id = recipe.id;
            context.SaveChanges(); 
        }
    }
}
