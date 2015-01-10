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

        private String productName;

        private int count;


        public String ProductName { get { return productName; } set { productName = value; RaisePropertyChanged(); } }

        public int Count { get { return count; } set { count = value; RaisePropertyChanged(); } }
    }
}
