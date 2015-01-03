using AppieApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppieApplication.ViewModel
{
    public class RecipeListViewModel : ViewModelBase
    {
        private IRecipeRepository repo;

        private RecipeViewModel _selectedRecipe;

        public RecipeViewModel SelectedRecipe {
            get { return _selectedRecipe; } 
            set { _selectedRecipe = value; 
                RaisePropertyChanged(); } 
        }

        private RecipeViewModel _inputRecipe;

        public RecipeViewModel InputRecipe
        {
           
            set
            {
                _inputRecipe = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<RecipeViewModel> Recipes { get; set; }

        public ICommand AddRecipeCommand { get; set; }

        public ICommand DeleteRecipeCommand { get; set; }


        public RecipeListViewModel()
        {

            repo = new RecipeRepository();

            var recipeList = repo.GetAll().Select(r => new RecipeViewModel(r));
            Recipes = new ObservableCollection<RecipeViewModel>(recipeList);

            AddRecipeCommand = new RelayCommand(AddRecipe, CanAddRecipe);
            DeleteRecipeCommand = new RelayCommand(DeleteRecipe, CanDeleteRecipe);

        }

      
        private void AddRecipe()
        {
            RecipeViewModel rvm = new RecipeViewModel();
            
            rvm.Name = _inputRecipe.Name;

            Recipe r = new Recipe();
            r.Name = rvm.Name;

            repo.Create(r);

            Recipes.Add(rvm);

        }

        private bool CanAddRecipe()
        {

            return true;
        }


        private void DeleteRecipe()
        {
            repo.Delete(SelectedRecipe.Id);
            Recipes.Remove(SelectedRecipe);
            SelectedRecipe = new RecipeViewModel();
        }

        public bool CanDeleteRecipe()
        {
            return SelectedRecipe != null;
        }

       
    }
}
