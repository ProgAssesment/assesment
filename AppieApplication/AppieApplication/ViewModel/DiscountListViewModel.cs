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
        private IBrandRepository repoBrand;

        private int _inputBrandId;

        public int InputBrandId { get { return _inputBrandId; } set { _inputBrandId = value; RaisePropertyChanged(); } }


        private DiscountViewModel _selectedDiscount;

        public DiscountViewModel SelectedDiscount { get { return _selectedDiscount; } set { _selectedDiscount = value; RaisePropertyChanged(); } }

        private DiscountViewModel _updateDiscount;

        public DiscountViewModel UpdateSelectedDiscount { get { return _updateDiscount; } set { _updateDiscount = value; RaisePropertyChanged(); } }


        private DateTime _inputDiscountStartDate;
        private DateTime _inputDiscountEndDate;

        public DateTime InputDiscountStartDate { get { return _inputDiscountStartDate; } set { _inputDiscountStartDate = value; RaisePropertyChanged(); } }
        public DateTime InputDiscountEndDate { get { return _inputDiscountEndDate; } set { _inputDiscountEndDate = value; RaisePropertyChanged(); } }

        public ObservableCollection<DiscountViewModel> Discounts { get; set; }

        public ICommand AddDiscountCommand { get; set; }
        public ICommand DeleteDiscountCommand { get; set; }
        public ICommand UpdateDiscountCommand { get; set; }



        public DiscountListViewModel()
        {

            repo = new DiscountRepository();
            repoBrand = new BrandRepository();

            var discountList = repo.GetAll().Select(d => new DiscountViewModel(d));
            Discounts = new ObservableCollection<DiscountViewModel>(discountList);

            AddDiscountCommand = new RelayCommand(AddDiscount,CanAddDiscount);
            DeleteDiscountCommand = new RelayCommand(DeleteDiscount);
            UpdateDiscountCommand = new RelayCommand(UpdateDiscount);
            


        }

        public void AddDiscount()
        {

            DiscountViewModel dvm = new DiscountViewModel();
            dvm.StartDate = InputDiscountStartDate;
            dvm.EndDate = InputDiscountEndDate;
            int idBrand = InputBrandId;
            
            Discount d = new Discount();
            d.StartDate = dvm.StartDate;
            d.EndDate = dvm.EndDate;
            d.BrandId = idBrand;
            repo.Create(d);

            idBrand = repoBrand.GetByName(repoBrand.Get(idBrand).Name).id;


            Discounts.Add(dvm);

        }

        private bool CanAddDiscount()
        {

            return true;
        }

        public void UpdateDiscount()
        {
            UpdateSelectedDiscount.StartDate = SelectedDiscount.StartDate;
            UpdateSelectedDiscount.EndDate = SelectedDiscount.EndDate;
            UpdateSelectedDiscount.Coupon = SelectedDiscount.Coupon;

            Discount d = new Discount();

            d.StartDate = UpdateSelectedDiscount.StartDate;
            d.EndDate = UpdateSelectedDiscount.EndDate;
            d.Coupon = UpdateSelectedDiscount.Coupon;
            
            repo.Edit(d);

            //    rvm.Id = repo.GetByName(r.Name).id;
            
            Discounts.Remove(SelectedDiscount);
            Discounts.Add(UpdateSelectedDiscount);

        }

        private bool CanUpdateDiscount()
        {

            return true;
        }


        private void DeleteDiscount()
        {
            Discount d = repo.Get(_selectedDiscount.Coupon);
            repo.Delete(d);
            Discounts.Remove(_selectedDiscount);
            SelectedDiscount = new DiscountViewModel();

        }

        public bool CanDeleteDiscount()
        {
            return SelectedDiscount != null;
        }
    }

}
