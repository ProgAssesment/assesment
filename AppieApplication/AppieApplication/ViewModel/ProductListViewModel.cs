using AppieApplication.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.ViewModel
{
    public class ProductListViewModel : ViewModelBase
    {

        private IProductRepository repo;

        private ProductViewModel selectedProduct;

        public ProductViewModel SelectedProduct { get { return selectedProduct; } set { selectedProduct = value; RaisePropertyChanged(); } }

        public ObservableCollection<ProductViewModel> Products { get; set; }

        public ProductListViewModel(Catagory catagory)
        {

            repo = new ProductRepository();
            var productList = repo.GetAll().Where(x => x.CatagoryId.Equals(catagory.Id)).Select(p => new ProductViewModel(p));
            Products = new ObservableCollection<ProductViewModel>(productList);

        }

    }
}
