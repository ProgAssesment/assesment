using AppieApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

        private RecipeViewModel _updateRecipe;

        public RecipeViewModel UpdateSelectedRecipe { get { return _updateRecipe; } set { _updateRecipe = value; RaisePropertyChanged(); } }


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

        public ICommand DeleteRecipeCommand { get; set; }

        public ICommand OpenIngredientsWindowCommand { get; set; }
        public ICommand UpdateRecipeCommand { get; set; }

        public RecipeListViewModel()
        {

            repo = new RecipeRepository();

            var recipeList = repo.GetAll().Select(r => new RecipeViewModel(r));
            Recipes = new ObservableCollection<RecipeViewModel>(recipeList);

            brandsWindow = new BrandWindow();

            AddRecipeCommand = new RelayCommand(AddRecipe, CanAddRecipe);
            DeleteRecipeCommand = new RelayCommand(DeleteRecipe);
            UpdateRecipeCommand = new RelayCommand(UpdateDiscount);
            OpenIngredientsWindowCommand = new RelayCommand(OpenIngredientsWindow);

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


        private void AddRecipe()
        {
            RecipeViewModel rvm = new RecipeViewModel();

            rvm.Name = InputRecipe;

            Recipe r = new Recipe();
            r.Name = rvm.Name;

            repo.Create(r);

            rvm.Id = repo.GetByName(r.Name).id;

            Recipes.Add(rvm);

        }

        private bool CanAddRecipe()
        {
            return true;
        }


        public void UpdateDiscount()
        {
            UpdateSelectedRecipe.Name = SelectedRecipe.Name;
            UpdateSelectedRecipe.Id = SelectedRecipe.Id;

            Recipe r = new Recipe();

            r.Name = UpdateSelectedRecipe.Name;
            r.id = UpdateSelectedRecipe.Id;

            repo.Edit(r);


            Recipes.Remove(SelectedRecipe);
            Recipes.Add(UpdateSelectedRecipe);

        }

        private bool CanUpdateDiscount()
        {

            return true;
        }



        private void DeleteRecipe()
        {
            Recipe r = repo.Get(_selectedRecipe.Id);
            repo.Delete(r);
            Recipes.Remove(_selectedRecipe);
            SelectedRecipe = new RecipeViewModel();
        }

        public bool CanDeleteRecipe()
        {
            if (SelectedRecipe != null)
            {
                return true;
            }

            return false;
        }


    }
}
