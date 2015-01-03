/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:AppieApplication"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using AppieApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace AppieApplication.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ProductListViewModel>();
            SimpleIoc.Default.Register<CatagoryListViewModel>();
            SimpleIoc.Default.Register<DiscountListViewModel>();
            SimpleIoc.Default.Register<RecipeListViewModel>();
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
        public DiscountListViewModel DiscountListViewModel { get { return ServiceLocator.Current.GetInstance<DiscountListViewModel>(); } }
        public RecipeListViewModel RecipeListViewModel { get { return ServiceLocator.Current.GetInstance<RecipeListViewModel>(); } }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}