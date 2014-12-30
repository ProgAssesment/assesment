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
    public class CatagoryListViewModel : ViewModelBase
    {

        private ICatagoryRepository repo;

        private CatagoryViewModel selectedCatagory;

        public ObservableCollection<CatagoryViewModel> Catagories { get; set; }

        public CatagoryListViewModel()
        {
            repo = new CatagoryRepository();
            var catagoryList = repo.GetAll().Select(c => new CatagoryViewModel(c));
            Catagories = new ObservableCollection<CatagoryViewModel>(catagoryList);
        }

    }
}
