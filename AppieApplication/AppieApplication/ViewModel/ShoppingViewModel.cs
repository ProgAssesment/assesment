using AppieApplication.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.ViewModel
{
    public class ShoppingViewModel : ViewModelBase
    {

        private int count;

        private Brand brand;

        public ShoppingViewModel(Brand brand)
        {
            this.brand = brand;
            count = 1;
        }

        //set mag weg?
        public String ProductName { get { return brand.Product.Name; } set { brand.Product.Name = value; RaisePropertyChanged(); } }

        public int Count { get { return count; } set { count = value; RaisePropertyChanged(); } }

        public double Price { get { return brand.Price; }}
    }
}
