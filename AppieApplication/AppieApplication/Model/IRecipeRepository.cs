using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public interface IRecipeRepository
    {
        List<Recipe> GetAll();
        Recipe Get(int id);
        void Delete(int id);
        void Create(Recipe recipe);
        void Edit(Recipe recipe);

    }
}
