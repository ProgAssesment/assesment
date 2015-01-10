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

        private int catagoryId;

        private String productName;

        public String ProductName { get { return productName; } set { productName = value; RaisePropertyChanged(); } }

        public ProductViewModel SelectedProduct { get { return selectedProduct; } set { selectedProduct = value; RaisePropertyChanged(); } }

        public ObservableCollection<ProductViewModel> Products { get { return products; } set { products = value; RaisePropertyChanged(); } }

        public ICommand OpenBrandsWindowCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand AddProductCommand { get; set; }

        public ProductListViewModel(IProductRepository repo)
        {
            this.repo = repo;
            Messenger.Default.Register<NotificationMessage<int>>(this, OnHitIt);
            var productList = repo.GetAll().Where(x => x.CatagoryId.Equals(2)).Select(p => new ProductViewModel(p));
            Products = new ObservableCollection<ProductViewModel>(productList);

            brandWindow = new BrandWindow();
            OpenBrandsWindowCommand = new RelayCommand(OpenBrandsWindow, CanOpenBrandsWindow);
            DeleteProductCommand = new RelayCommand(DeleteProduct, CanDeleteProduct);
            AddProductCommand = new RelayCommand(AddProduct, CanAddProduct);

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

        public bool CanAddProduct()
        {
            return productName != null;
        }

        public void AddProduct()
        {
            ProductViewModel pvm = new ProductViewModel();
            pvm.Name = productName;

            Product p = new Product();
            p.Name = pvm.Name;
            p.CatagoryId = catagoryId;

            repo.Create(p);
            pvm.Id = repo.GetByName(p.Name).Id;

            Products.Add(pvm);
        }

        public bool CanEditProduct()
        {
            return SelectedProduct != null;
        }

        public void EditProduct()
        {
            Product p = repo.Get(selectedProduct.Id);
            p.Name = selectedProduct.Name;

            repo.Edit(p);
        }

        public bool CanDeleteProduct()
        {
            return SelectedProduct != null;
        }

        public void DeleteProduct()
        {
            Product p = repo.Get(selectedProduct.Id);
            repo.Delete(p);
            products.Remove(selectedProduct);
            SelectedProduct = new ProductViewModel();

        }

        private void OnHitIt(NotificationMessage<int> m)
        {
            if (m.Notification == "catagory")
            {
                var productList = repo.GetAll().Where(x => x.CatagoryId.Equals(m.Content)).Select(p => new ProductViewModel(p));
                Products = new ObservableCollection<ProductViewModel>(productList);
                catagoryId = m.Content;
            }
        }

    }
}
