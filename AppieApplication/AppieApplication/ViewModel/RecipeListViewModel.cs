using AppieApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
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
        private BrandWindow brandsWindow;

        private IRecipeRepository repo;

        //FOR TEST
         private IBrandRepository repoBrand;

        private RecipeViewModel _selectedRecipe;

        public RecipeViewModel SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                RaisePropertyChanged();
            }
        }

        private string _inputRecipe;

        public String InputRecipe
        {
            get { return _inputRecipe; }
            set
            {
                _inputRecipe = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<RecipeViewModel> Recipes { get; set; }

        public ICommand AddRecipeCommand { get; set; }
        public ICommand AddRecipeProductsToShoplistCommand { get; set; }

        public ICommand DeleteRecipeCommand { get; set; }

        public ICommand OpenIngredientsWindowCommand { get; set; }
        public ICommand UpdateRecipeCommand { get; set; }

          public RecipeListViewModel(IRecipeRepository repo, IBrandRepository repoBrand)
         {

        //FOR TEST
      //  public RecipeListViewModel(IRecipeRepository repo)
       // {

            this.repo = repo;

            //FOR TEST
               this.repoBrand = repoBrand;

            var recipeList = repo.GetAll().Select(r => new RecipeViewModel(r));
            Recipes = new ObservableCollection<RecipeViewModel>(recipeList);

            //FOR TEST
             brandsWindow = new BrandWindow();

            AddRecipeCommand = new RelayCommand(AddRecipe, CanAddRecipe);
            DeleteRecipeCommand = new RelayCommand(DeleteRecipe, CanDeleteRecipe);
            UpdateRecipeCommand = new RelayCommand(UpdateRecipe, CanUpdateRecipe);
            OpenIngredientsWindowCommand = new RelayCommand(OpenIngredientsWindow, CanOpenIngredientsWindow);
            AddRecipeProductsToShoplistCommand = new RelayCommand(AddProductToShoppingList, CanAddProductToShoppingList);

        }

        public bool CanOpenIngredientsWindow()
        {

            if (_selectedRecipe != null)
            {
                return true;
            }

            return false;
        }

        public void OpenIngredientsWindow()
        {
            brandsWindow = new BrandWindow();
            Messenger.Default.Send(new NotificationMessage<int>(SelectedRecipe.Id, "recipe"));
            brandsWindow.Show();
        }

        public bool CanAddProductToShoppingList()
        {
            return SelectedRecipe != null;
        }

        public void AddProductToShoppingList()
        {

            Recipe r = repo.Get(SelectedRecipe.Id);


            foreach (Brand b in r.Products)
            {
                repo.AddToShoppingList(b);
            }

        }


        public void AddRecipe()
        {
            RecipeViewModel rvm = new RecipeViewModel();

            rvm.Name = InputRecipe;

            Recipe r = new Recipe();
            r.Name = rvm.Name;

            repo.Create(r);

            //FOR TEST
            rvm.Id = repo.GetByName(r.Name).id;

            Recipes.Add(rvm);

        }

        private bool CanAddRecipe()
        {
            return true;
        }


        public void UpdateRecipe()
        {
            //FOR TEST
            Recipe r = repo.Get(SelectedRecipe.Id);

            //FOR TEST
            //Recipe r = repo.Get(1);

            r.Name = SelectedRecipe.Name;

            repo.Edit(r);

        }

        private bool CanUpdateRecipe()
        {

            return SelectedRecipe != null;
        }



        public void DeleteRecipe()
        {
            Recipe r = repo.Get(_selectedRecipe.Id);
            repo.Delete(r);
            Recipes.Remove(_selectedRecipe);
            SelectedRecipe = new RecipeViewModel();
        }

        private bool CanDeleteRecipe()
        {
            if (SelectedRecipe != null)
            {
                return true;
            }

            return false;


        }


    }
}
