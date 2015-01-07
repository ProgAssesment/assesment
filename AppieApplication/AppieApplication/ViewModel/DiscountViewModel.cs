using AppieApplication.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.ViewModel
{
    public class DiscountViewModel : ViewModelBase
    {

        public int Coupon { get { return discount.Coupon; } set { discount.Coupon = value; RaisePropertyChanged(); } }

        public DateTime StartDate { get { return discount.StartDate; } set { discount.StartDate = value; RaisePropertyChanged(); } }

        public DateTime EndDate { get { return discount.EndDate; } set { discount.EndDate = value; RaisePropertyChanged(); } }

        public int BrandId { get { return discount.BrandId; } set { discount.BrandId = value; RaisePropertyChanged(); } }


        private Discount discount;

        public DiscountViewModel()
        {
            this.discount = new Discount();
        }

        public DiscountViewModel(Discount discount)
        {
            this.discount = discount;
        }

    }
}
