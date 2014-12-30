using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;

namespace AppieApplication.ViewModel
{

    public class WindowsViewModel : ViewModelBase
    {

        private CatagoryWindow catagoryWindow;

        public ICommand ShowCatagoriesWindowCommand { get; set; }

        public WindowsViewModel()
        {
            catagoryWindow = new CatagoryWindow();
            ShowCatagoriesWindowCommand = new RelayCommand(showCatagoriesWindow, canShowCatagoriesWindow);
        }

        private bool canShowCatagoriesWindow()
        {
            return catagoryWindow.IsVisible == false;
        }

        private void showCatagoriesWindow()
        {
            catagoryWindow.Show();
        }

    }
}