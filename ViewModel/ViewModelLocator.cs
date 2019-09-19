/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Fundusz2"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation; //TODO <- USUN¥Æ REFERENCJÊ!
using System.Windows;

namespace Fundusz2.ViewModel {
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator {
        public static bool trybProjetowania = true;
        public ViewModelLocator() {
            //ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default); //- powoduje b³êdy!!

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    // Create design time view services and models
            //    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            //}
            //else
            //{
            //    // Create run time view services and models
            //    SimpleIoc.Default.Register<IDataService, DataService>();
            //}
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TestViewModel>();
            SimpleIoc.Default.Register<UczestnicyViewModel>();
        }

        public MainViewModel MainVM {
            get {
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }
        public UczestnicyViewModel UczestnicyVM {
            get {
                return SimpleIoc.Default.GetInstance<UczestnicyViewModel>();
            }
        }
        public TestViewModel Test1 {
            get {
                return SimpleIoc.Default.GetInstance<TestViewModel>();
            }
        }

        public static void Cleanup() {
            // TODO Clear the ViewModels
        }
    }
}