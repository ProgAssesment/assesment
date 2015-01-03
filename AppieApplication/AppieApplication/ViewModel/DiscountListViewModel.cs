using AppieApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppieApplication.ViewModel
{
    public class DiscountListViewModel : ViewModelBase
    {
        private IDiscountRepository repo;

        private DiscountViewModel _selectedDiscount;

        public DiscountViewModel SelectedDiscount { get { return _selectedDiscount; } set { _selectedDiscount = value; RaisePropertyChanged(); } }

        public ObservableCollection<DiscountViewModel> Discounts { get; set; }

        public ICommand AddDiscountCommand { get; set; }
        public ICommand DeleteDiscountCommand { get; set; }



        public DiscountListViewModel()
        {

            repo = new DiscountRepository();
            var discountList = repo.GetAll().Select(d => new DiscountViewModel(d));
            Discounts = new ObservableCollection<DiscountViewModel>(discountList);

            AddDiscountCommand = new RelayCommand(AddDiscount,CanAddDiscount);
            DeleteDiscountCommand = new RelayCommand(DeleteDiscount);

            SelectedDiscount = new DiscountViewModel();

        }

        public void AddDiscount()
        {

            var svm = new DiscountViewModel();

            svm.StartDate = SelectedDiscount.StartDate;
            svm.EndDate = SelectedDiscount.EndDate;


            Discount d = new Discount();
            d.StartDate = svm.StartDate;
            d.EndDate = svm.EndDate;

            repo.Create(d);


            Discounts.Add(svm);

            //DiscountViewModel dvm = new DiscountViewModel();
            //dvm.StartDate = SelectedDiscount.StartDate;
            //dvm.EndDate = SelectedDiscount.EndDate;



            //Discounts.Add(dvm);

        }

        private bool CanAddDiscount()
        {

            return true;
        }

        private void DeleteDiscount()
        {
            repo.Delete(SelectedDiscount.Coupon);
            Discounts.Remove(SelectedDiscount);

            SelectedDiscount = new DiscountViewModel();
        }

        public bool CanDeleteDiscount()
        {
            return SelectedDiscount != null;
        }
    }

}
