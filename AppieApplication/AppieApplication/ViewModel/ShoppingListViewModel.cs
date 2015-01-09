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

        private ShoppingList shoppingList;

        public ShoppingList ShoppingListtmp { get { return shoppingList; } set { shoppingList = value; RaisePropertyChanged(); } }

        private ObservableCollection<BrandViewModel> brands;

        public ObservableCollection<BrandViewModel> Brands { get { return brands; } set { brands = value; RaisePropertyChanged(); } }


        public ShoppingListViewModel(IShoppingListRepository repo)
        {
            this.repo = repo;
            ShoppingListtmp = repo.Get(listId);
            var list = ShoppingListtmp.Products.Select(b => new BrandViewModel(b));
            Brands = new ObservableCollection<BrandViewModel>(list);
        }



    }
}
