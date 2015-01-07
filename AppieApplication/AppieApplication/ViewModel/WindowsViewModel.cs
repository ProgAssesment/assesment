using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;

namespace AppieApplication.ViewModel
{

    public class WindowsViewModel : ViewModelBase
    {

        private CatagoryWindow catagoryWindow;
        private RecipesWindow recipesWindow;


        //for testing
        private DiscountsWindow discountsWindow;
        public ICommand ShowDiscountsWindowCommand { get; set; }

        public ICommand ShowCatagoriesWindowCommand { get; set; }
        public ICommand ShowRecipesWindowCommand { get; set; }


        public WindowsViewModel()
        {
            catagoryWindow = new CatagoryWindow();
            recipesWindow = new RecipesWindow();

            //for testing
            discountsWindow = new DiscountsWindow();
            ShowDiscountsWindowCommand = new RelayCommand(showDiscountsWindow, canShowDiscountsWindow);

            ShowCatagoriesWindowCommand = new RelayCommand(showCatagoriesWindow, canShowCatagoriesWindow);
            ShowRecipesWindowCommand = new RelayCommand(showRecipesWindow, canShowRecipesWindow);

        }

        private bool canShowCatagoriesWindow()
        {
            return catagoryWindow.IsVisible == false;
        }

        private void showCatagoriesWindow()
        {
            catagoryWindow = new CatagoryWindow();
            catagoryWindow.Show();
        }

        private bool canShowRecipesWindow()
        {
            return recipesWindow.IsVisible == false;
        }

        private void showRecipesWindow()
        {
            recipesWindow = new RecipesWindow();
            recipesWindow.Show();
        }

        //for testing
        private bool canShowDiscountsWindow()
        {
            return discountsWindow.IsVisible == false;
        }
        private void showDiscountsWindow()
        {
            discountsWindow = new DiscountsWindow();
            discountsWindow.Show();
        }

    }
}