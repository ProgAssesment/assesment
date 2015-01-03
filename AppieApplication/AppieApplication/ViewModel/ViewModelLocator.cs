using AppieApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace AppieApplication.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ProductListViewModel>();
            SimpleIoc.Default.Register<CatagoryListViewModel>();
            SimpleIoc.Default.Register<BrandListViewModel>();
            SimpleIoc.Default.Register<WindowsViewModel>();
        }

        public WindowsViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WindowsViewModel>();
            }
        }

        public ProductListViewModel ProductListViewModel { get { return ServiceLocator.Current.GetInstance<ProductListViewModel>(); } }
        public CatagoryListViewModel CatagoryListViewModel { get { return ServiceLocator.Current.GetInstance<CatagoryListViewModel>(); } }
        public BrandListViewModel BrandListViewModel { get { return ServiceLocator.Current.GetInstance<BrandListViewModel>(); } }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}