using AppieApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.ViewModel
{
    public class ProductListViewModel : ViewModelBase
    {

        private Catagory catagory = new Catagory();

        private IProductRepository repo;

        private ProductViewModel selectedProduct;

        private ObservableCollection<ProductViewModel> products;

        public ProductViewModel SelectedProduct { get { return selectedProduct; } set { selectedProduct = value; RaisePropertyChanged(); } }

        public ObservableCollection<ProductViewModel> Products { get { return products; } set { products = value; RaisePropertyChanged(); } }

        public ProductListViewModel()
        {
            repo = new ProductRepository();
            Messenger.Default.Register<NotificationMessage<int>>(this, OnHitIt);
            var productList = repo.GetAll().Where(x => x.CatagoryId.Equals(2)).Select(p => new ProductViewModel(p));
            Products = new ObservableCollection<ProductViewModel>(productList);
        }

        private void OnHitIt(NotificationMessage<int> m)
        {
            if (m.Notification == "token")
            {

                Debug.WriteLine("CONTENT: " + m.Content);
                var productList = repo.GetAll().Where(x => x.CatagoryId.Equals(m.Content)).Select(p => new ProductViewModel(p));
                Products = new ObservableCollection<ProductViewModel>(productList);
                Debug.WriteLine("PVM: " + Products.Count());

            }
        }

    }
}
