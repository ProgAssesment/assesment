using AppieApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
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

        //FOR TEST
        private IBrandRepository repoBrand;

        private BrandViewModel brandsName;

        public BrandViewModel BrandsName { get { return brandsName; } set { brandsName = value; RaisePropertyChanged(); } }

        private ObservableCollection<BrandViewModel> brands;

        public ObservableCollection<BrandViewModel> Brands { get { return brands; } set { brands = value; RaisePropertyChanged(); } }

        private DiscountViewModel _selectedDiscount;

        public DiscountViewModel SelectedDiscount { get { return _selectedDiscount; } set { _selectedDiscount = value; RaisePropertyChanged(); } }

        private DateTime _inputDiscountStartDate;
        private DateTime _inputDiscountEndDate;

        public DateTime InputDiscountStartDate { get { return _inputDiscountStartDate; } set { _inputDiscountStartDate = value; RaisePropertyChanged(); } }
        public DateTime InputDiscountEndDate { get { return _inputDiscountEndDate; } set { _inputDiscountEndDate = value; RaisePropertyChanged(); } }

        public double _inputDiscount;

        public Double InputDiscount { get { return _inputDiscount; } set { _inputDiscount = value; RaisePropertyChanged(); } }


        public ObservableCollection<DiscountViewModel> Discounts { get; set; }

        public ICommand AddDiscountCommand { get; set; }
        public ICommand DeleteDiscountCommand { get; set; }
        public ICommand UpdateDiscountCommand { get; set; }


         public DiscountListViewModel(IDiscountRepository repo, IBrandRepository repoBrand)
     
        //FOR TEST
      //  public DiscountListViewModel(IDiscountRepository repo)
        {

            this.repo = repo;

            //FOR TEST
            this.repoBrand = repoBrand;

            var discountList = repo.GetAll().Select(d => new DiscountViewModel(d));
            Discounts = new ObservableCollection<DiscountViewModel>(discountList);

            AddDiscountCommand = new RelayCommand(AddDiscount, CanAddDiscount);
            DeleteDiscountCommand = new RelayCommand(DeleteDiscount, CanDeleteDiscount);
            UpdateDiscountCommand = new RelayCommand(UpdateDiscount, CanUpdateDiscount);

            Messenger.Default.Register<NotificationMessage<int>>(this, OnHitIt);

            var brandList = repoBrand.GetAll().Select(d => new BrandViewModel(d));
            Brands = new ObservableCollection<BrandViewModel>(brandList);
       
        }

        public void AddDiscount()
        {

            DiscountViewModel dvm = new DiscountViewModel();
            dvm.StartDate = InputDiscountStartDate;
            dvm.EndDate = InputDiscountEndDate;
            //FOR TEST
            dvm.BrandId = BrandsName.Id;
            dvm.PriceReduction = InputDiscount;

            Discount d = new Discount();
            d.StartDate = dvm.StartDate;
            d.EndDate = dvm.EndDate;
            //FOR TEST
            d.BrandId = dvm.BrandId;
            d.PriceReduction = dvm.PriceReduction;

            repo.Create(d);

            dvm.Coupon = repo.GetAll().Last().Coupon;
            //FOR TEST
            dvm.BrandId = repoBrand.GetByName(repoBrand.Get(dvm.BrandId).Name).id;

            Discounts.Add(dvm);

        }

        private bool CanAddDiscount()
        {

            return true;
        }

        public void UpdateDiscount()
        {
            Discount d = repo.Get(SelectedDiscount.Coupon);
            d.StartDate = SelectedDiscount.StartDate;
            d.EndDate = SelectedDiscount.EndDate;
            d.BrandId = SelectedDiscount.BrandId;
            d.PriceReduction = SelectedDiscount.PriceReduction;

            repo.Edit(d);

        }

        private bool CanUpdateDiscount()
        {

            return true;
        }


        public void DeleteDiscount()
        {
            Discount d = repo.Get(_selectedDiscount.Coupon);
            repo.Delete(d);
            Discounts.Remove(_selectedDiscount);
            SelectedDiscount = new DiscountViewModel();

        }

        private bool CanDeleteDiscount()
        {
            return SelectedDiscount != null;
        }

        private void OnHitIt(NotificationMessage<int> m)
        {
            if (m.Notification == "refreshDiscounts")
            {
                var brandList = repoBrand.GetAll().Select(d => new BrandViewModel(d));
                Brands = new ObservableCollection<BrandViewModel>(brandList);
            }
        }
    }

}
