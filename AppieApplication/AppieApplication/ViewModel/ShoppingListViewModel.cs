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
    public class ShoppingListViewModel : ViewModelBase
    {

        private IShoppingListRepository repo;

        private ObservableCollection<ShoppingViewModel> svmList;

        public ObservableCollection<ShoppingViewModel> SvmList { get { return svmList; } set { svmList = value; RaisePropertyChanged(); } }

        private double totalPrice;

        public double TotalPrice { get { return totalPrice; } set { totalPrice = value; RaisePropertyChanged(); } }

        public ShoppingListViewModel(IShoppingListRepository repo)
        {
            Messenger.Default.Register<NotificationMessage<int>>(this, OnHitIt);
            this.repo = repo;
            SetupList();
        }

        public void SetupList()
        {
            TotalPrice = 0;

           repo = new ShoppingListRepository();
            SvmList = new ObservableCollection<ShoppingViewModel>();

            List<ShoppingList> list = repo.GetAll();

            foreach (ShoppingList sl in list)
            {
                bool add = true;

                foreach (ShoppingViewModel s in SvmList)
                {

                    if (s.ProductName.Equals(sl.brand.Product.Name))
                    {
                        s.Count += sl.Count;
                        if (sl.brand.Discounts.Where(x => x.StartDate <= DateTime.Now && DateTime.Now <= x.EndDate).FirstOrDefault() != null)
                        {
                            TotalPrice += ((sl.brand.Price - sl.brand.Discounts.Where(x => x.StartDate <= DateTime.Now && DateTime.Now <= x.EndDate).First().PriceReduction) * sl.Count);

                        }
                        else
                        {
                            TotalPrice += (sl.brand.Price * sl.Count);
                        }
                        add = false;
                        break;
                    }
                }

                if (add)
                {
                    ShoppingViewModel svm = new ShoppingViewModel();
                    svm.ProductName = sl.brand.Product.Name;
                    svm.Count = sl.Count;
                    SvmList.Add(svm);
                    if (sl.brand.Discounts.Where(x => x.StartDate <= DateTime.Now && DateTime.Now <= x.EndDate).FirstOrDefault() != null)
                    {
                        TotalPrice += ((sl.brand.Price - sl.brand.Discounts.Where(x => x.StartDate <= DateTime.Now && DateTime.Now <= x.EndDate).First().PriceReduction) * sl.Count);

                    }
                    else
                    {
                        TotalPrice += (sl.brand.Price * sl.Count);
                    }
                }

            }

        }

        private void OnHitIt(NotificationMessage<int> m)
        {
            if (m.Notification == "refreshList")
            {
                SetupList();
            }
        }


    }
}
