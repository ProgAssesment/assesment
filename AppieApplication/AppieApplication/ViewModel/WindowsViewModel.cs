using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace AppieApplication.ViewModel
{

    public class WindowsViewModel : ViewModelBase
    {

        private CatagoryWindow catagoryWindow;
        private RecipesWindow recipesWindow;
        private ShoppingListWindow shoppingListWindow;


        //for testing
        private DiscountsWindow discountsWindow;
        public ICommand ShowDiscountsWindowCommand { get; set; }
        public ICommand ShowShoppingListWindowCommand { get; set; }
        public ICommand ShowCatagoriesWindowCommand { get; set; }
        public ICommand ShowRecipesWindowCommand { get; set; }


        public WindowsViewModel()
        {
            catagoryWindow = new CatagoryWindow();
            recipesWindow = new RecipesWindow();
            shoppingListWindow = new ShoppingListWindow();

            //for testing
            discountsWindow = new DiscountsWindow();
            ShowDiscountsWindowCommand = new RelayCommand(showDiscountsWindow, canShowDiscountsWindow);

            ShowCatagoriesWindowCommand = new RelayCommand(showCatagoriesWindow, canShowCatagoriesWindow);
            ShowRecipesWindowCommand = new RelayCommand(showRecipesWindow, canShowRecipesWindow);
            ShowShoppingListWindowCommand = new RelayCommand(ShowShoppingListWindow, CanShowShoppingListWindow);

        }

        public bool CanShowShoppingListWindow()
        {
            return shoppingListWindow.IsVisible == false;
        }


            //HOOFDLETTERS
        private bool canShowCatagoriesWindow()
        {
            return catagoryWindow.IsVisible == false;
        }

        public void ShowShoppingListWindow()
        {
            shoppingListWindow = new ShoppingListWindow();
            Messenger.Default.Send(new NotificationMessage<int>(0, "refreshList"));
            shoppingListWindow.Show();
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
            Messenger.Default.Send(new NotificationMessage<int>(0, "refreshDiscounts"));
            discountsWindow.Show();
        }

    }
}