using AppieApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppieApplication.ViewModel
{
    public class CatagoryListViewModel : ViewModelBase
    {

        private ProductsWindow productsWindow;
        private ICatagoryRepository repo;

        private CatagoryViewModel selectedCatagory;

        public CatagoryViewModel SelectedCatagory { get { return selectedCatagory; } set { selectedCatagory = value; RaisePropertyChanged(); } }

        public ObservableCollection<CatagoryViewModel> Catagories { get; set; }

        public ICommand AddCatagoryCommand { get; set; }

        public ICommand OpenProductsWindowCommand { get; set; }

        public CatagoryListViewModel()
        {
            repo = new CatagoryRepository();
            var catagoryList = repo.GetAll().Select(c => new CatagoryViewModel(c));
            Catagories = new ObservableCollection<CatagoryViewModel>(catagoryList);
            productsWindow = new ProductsWindow();
            AddCatagoryCommand = new RelayCommand(AddCatagory, CanAddCatagory);
            OpenProductsWindowCommand = new RelayCommand(OpenProductsWindow, CanOpenProductsWindow);
        }

        public bool CanOpenProductsWindow()
        {

            if (selectedCatagory != null)
            {
                return true;
            }

            return false;
        }

        public void OpenProductsWindow()
        {
            Messenger.Default.Send(new NotificationMessage<int>(SelectedCatagory.Id, "token"));
            productsWindow.Show();
        }

        //Code toevoegen
        public bool CanAddCatagory()
        {
            return true;
        }

        public void AddCatagory()
        {

            CatagoryViewModel cvm = new CatagoryViewModel();
            cvm.Name = SelectedCatagory.Name;

            selectedCatagory = new CatagoryViewModel();

            Catagory c = new Catagory();
            c.Name = cvm.Name;

            repo.Create(c);

            cvm.Id = repo.GetByName(c.Name).Id;

            Catagories.Add(cvm);
        }

    }
}
