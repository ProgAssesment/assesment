using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
   public class DummyRecipeRepository : IRecipeRepository
    {
        public List<Recipe> GetAll()
        {
            var recipes = new List<Recipe>();

            recipes.Add(new Recipe { id = 1, Name = "Madonna" });
            recipes.Add(new Recipe { id = 2, Name = "Prince"});
            recipes.Add(new Recipe { id = 3, Name = "Michael Jackson"});
            recipes.Add(new Recipe { id = 4, Name = "U2"});

            return recipes;
        }

        public Recipe Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Recipe recipe)
        {
            throw new NotImplementedException();

        }

        public void Edit(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
