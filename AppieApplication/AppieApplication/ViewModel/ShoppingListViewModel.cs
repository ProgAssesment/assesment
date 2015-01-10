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
    public class ShoppingListViewModel : ViewModelBase
    {

        private IShoppingListRepository repo;

        private int listId = 1;

        private ObservableCollection<ShoppingViewModel> svmList;

        public ObservableCollection<ShoppingViewModel> SvmList { get { return svmList; } set { svmList = value; RaisePropertyChanged(); } }

        public double TotalPrice { get; set; }

        public ShoppingListViewModel(IShoppingListRepository repo)
        {
            this.repo = repo;
            TotalPrice = 0;
            ShoppingList list = repo.Get(listId);
            SetupList(list);
        }

        private void SetupList(ShoppingList list)
        {

            SvmList = new ObservableCollection<ShoppingViewModel>();

            foreach (Brand b in list.Products)
            {

                bool add = true;

                foreach (ShoppingViewModel s in SvmList)
                {

                    if (s.ProductName.Equals(b.Product.Name))
                    {
                        s.Count += 1;
                        TotalPrice += s.Price;
                        add = false;
                        break;
                    }

                }

                if (add)
                {
                    ShoppingViewModel svm = new ShoppingViewModel(b);
                    SvmList.Add(svm);
                    TotalPrice += svm.Price;
                }

            }

        }


    }
}
