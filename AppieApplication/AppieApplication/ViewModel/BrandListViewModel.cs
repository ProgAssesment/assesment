using AppieApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.ViewModel
{
    public class BrandListViewModel : ViewModelBase
    {

        private IBrandRepository repo;

        private BrandViewModel selectedBrand;

        private ObservableCollection<BrandViewModel> brands;

        public BrandViewModel SelectedBrand { get { return selectedBrand; } set { selectedBrand = value; RaisePropertyChanged(); } }

        public ObservableCollection<BrandViewModel> Brands { get { return brands; } set { brands = value; RaisePropertyChanged(); } }

        public BrandListViewModel()
        {
            repo = new BrandRepository();
            var brandList = repo.GetAll().Select(b => new BrandViewModel(b));
            Brands = new ObservableCollection<BrandViewModel>(brandList);
            Messenger.Default.Register<NotificationMessage<int>>(this, OnHitIt);

        }

        private void OnHitIt(NotificationMessage<int> m)
        {
            if (m.Notification == "product")
            {
                Debug.WriteLine("MESSAGE: " + m.Content);
                //.Where(x => x.ProductId.Equals(m.Content))
                var brandList = repo.GetAll().Select(b => new BrandViewModel(b));
                Debug.WriteLine("CONTENT:  " + brandList.ElementAt(0).Name);
                Brands = new ObservableCollection<BrandViewModel>(brandList);

                Debug.WriteLine("CONTENT2:  " + Brands.ElementAt(0).Name);
            }
        }
    }
}
