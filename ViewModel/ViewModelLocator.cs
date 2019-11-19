using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation; //TODO <- USUN¥Æ REFERENCJÊ!
using System.Windows;

namespace Fundusz2.ViewModel {
    public class ViewModelLocator {

        #region KONSTRUKTOR
        public ViewModelLocator() {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TestViewModel>(); //TODO wywalenia
            SimpleIoc.Default.Register<UczestnicyViewModel>();
            SimpleIoc.Default.Register<PozyczkiViewModel>();
            SimpleIoc.Default.Register<NowaPozyczkaViewModel>();
        }
        #endregion

        #region PROPERTIES (SimpleIoc)
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
        public NowaPozyczkaViewModel NowaPozyczkaVM {
            get {
                return SimpleIoc.Default.GetInstance<NowaPozyczkaViewModel>();
            }
        }
        
        //TODO do wywalenia
        public TestViewModel Test1 {
            get {
                return SimpleIoc.Default.GetInstance<TestViewModel>();
            }
        }
        #endregion
        
        public static void Cleanup() {
            // TODO Clear the ViewModels
        }
    }
}