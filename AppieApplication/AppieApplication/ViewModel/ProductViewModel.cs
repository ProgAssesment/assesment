using AppieApplication.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {

        public int Id { get { return product.Id; } set { product.Id = value; RaisePropertyChanged(); } }

        public String Type { get { return product.Type; } set { product.Type = value; RaisePropertyChanged(); } }
        public String Name { get { return product.Name; } set { product.Name = value; RaisePropertyChanged(); } }
        public String Brand { get { return product.Brand; } set { product.Brand = value; RaisePropertyChanged(); } }
        public double Price { get { return product.Price; } set { product.Price = value; RaisePropertyChanged(); } }

        private Product product;

        public ProductViewModel()
        {
            this.product = new Product();
        }

        public ProductViewModel(Product product)
        {
            this.product = product;
        }

        
    }
}
