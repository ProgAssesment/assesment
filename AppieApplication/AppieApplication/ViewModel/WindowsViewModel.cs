using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;

namespace AppieApplication.ViewModel
{

    public class WindowsViewModel : ViewModelBase
    {

        private ProductsWindow productsWindow;

        public ICommand ShowProductsWindowCommand { get; set; }

        public WindowsViewModel()
        {
            productsWindow = new ProductsWindow();
            ShowProductsWindowCommand = new RelayCommand(showProductsWindow, canShowProductsWindow);
        }

        private bool canShowProductsWindow()
        {
            return productsWindow.IsVisible == false;
        }

        private void showProductsWindow()
        {
            productsWindow.Show();
        }

    }
}