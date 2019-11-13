using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation; //TODO <- USUN¥Æ REFERENCJÊ!
using System.Windows;

namespace Fundusz2.ViewModel {
    public class ViewModelLocator {
        //public static bool trybProjetowania = true;
        public ViewModelLocator() {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TestViewModel>();
            SimpleIoc.Default.Register<UczestnicyViewModel>();
            SimpleIoc.Default.Register<PozyczkiViewModel>();
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
        public PozyczkiViewModel PozyczkiVM {
            get {
                return SimpleIoc.Default.GetInstance<PozyczkiViewModel>();
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