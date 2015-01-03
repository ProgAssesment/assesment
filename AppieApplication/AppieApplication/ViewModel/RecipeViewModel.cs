using AppieApplication.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.ViewModel
{
    public class RecipeViewModel : ViewModelBase
    {
        public int Id { get { return recipe.id; } set { recipe.id = value; RaisePropertyChanged(); } }

        public String Name { get { return recipe.Name; } set { recipe.Name = value; RaisePropertyChanged(); } }


        private Recipe recipe;

        public RecipeViewModel()
        {
            this.recipe = new Recipe();
        }

        public RecipeViewModel(Recipe recipes)
        {
            this.recipe = recipes;
        }

    }
}
