using AppieApplication.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.ViewModel
{
    public class BrandViewModel : ViewModelBase
    {

        private Brand brand;

        public BrandViewModel()
        {
            brand = new Brand();
        }

        public BrandViewModel(Brand brand)
        {
            this.brand = brand;
        }

        public int Id { get { return brand.id; } set { brand.id = value; RaisePropertyChanged(); } }
        public String Name { get { return brand.Name; } set { brand.Name = value; RaisePropertyChanged(); } }
        public double Price { get { return brand.Price; } set { brand.Price = value; RaisePropertyChanged(); } }


    }
}
