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
    public class ProductListViewModel : ViewModelBase
    {

        private IProductRepository repo;

        private ProductViewModel selectedProduct;

        private BrandWindow brandWindow;

        private ObservableCollection<ProductViewModel> products;

        public ProductViewModel SelectedProduct { get { return selectedProduct; } set { selectedProduct = value; RaisePropertyChanged(); } }

        public ObservableCollection<ProductViewModel> Products { get { return products; } set { products = value; RaisePropertyChanged(); } }

        public ICommand OpenBrandsWindowCommand { get; set; }

        public ProductListViewModel()
        {
            repo = new ProductRepository();
            Messenger.Default.Register<NotificationMessage<int>>(this, OnHitIt);
            var productList = repo.GetAll().Where(x => x.CatagoryId.Equals(2)).Select(p => new ProductViewModel(p));
            Products = new ObservableCollection<ProductViewModel>(productList);

            brandWindow = new BrandWindow();
            OpenBrandsWindowCommand = new RelayCommand(OpenBrandsWindow, CanOpenBrandsWindow);

        }

        public bool CanOpenBrandsWindow()
        {
            if (SelectedProduct != null)
            {
                return true;
            }

            return false;
        }

        public void OpenBrandsWindow()
        {
            brandWindow = new BrandWindow();
            Messenger.Default.Send(new NotificationMessage<int>(SelectedProduct.Id, "product"));
            brandWindow.Show();
        }

        private void OnHitIt(NotificationMessage<int> m)
        {
            if (m.Notification == "catagory")
            {
                var productList = repo.GetAll().Where(x => x.CatagoryId.Equals(m.Content)).Select(p => new ProductViewModel(p));
                Products = new ObservableCollection<ProductViewModel>(productList);
            }
        }

    }
}
