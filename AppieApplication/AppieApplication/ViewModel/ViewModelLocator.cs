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
<<<<<<< HEAD
            SimpleIoc.Default.Register<DiscountListViewModel>();
            SimpleIoc.Default.Register<RecipeListViewModel>();
=======
            SimpleIoc.Default.Register<BrandListViewModel>();
>>>>>>> 2c2e055b0db9ef5d414b4dd8149db52246b0baa3
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
<<<<<<< HEAD
        public DiscountListViewModel DiscountListViewModel { get { return ServiceLocator.Current.GetInstance<DiscountListViewModel>(); } }
        public RecipeListViewModel RecipeListViewModel { get { return ServiceLocator.Current.GetInstance<RecipeListViewModel>(); } }
=======
        public BrandListViewModel BrandListViewModel { get { return ServiceLocator.Current.GetInstance<BrandListViewModel>(); } }
>>>>>>> 2c2e055b0db9ef5d414b4dd8149db52246b0baa3


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}