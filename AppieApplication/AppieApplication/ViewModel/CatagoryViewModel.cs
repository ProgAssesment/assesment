using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class CatagoryViewModel : ViewModelBase
    {

        private Catagory catagory;

        public CatagoryViewModel()
        {
            catagory = new Catagory();
        }

        public CatagoryViewModel(Catagory catagory)
        {
            this.catagory = catagory;
        }


        public int Id { get { return catagory.Id; } set { catagory.Id = value; RaisePropertyChanged(); } }

        public String Name { get { return catagory.Name; } set { catagory.Name = value; RaisePropertyChanged(); } }

    }
}
