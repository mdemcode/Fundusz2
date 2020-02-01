using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation; //TODO <- USUN¥Æ REFERENCJÊ!
using System.Windows;

namespace Fundusz2.ViewModel {
    public class ViewModelLocator {

        #region KONSTRUKTOR
        public ViewModelLocator() {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<OperacjeViewModel>(); 
            SimpleIoc.Default.Register<UczestnicyViewModel>();
            SimpleIoc.Default.Register<PozyczkiViewModel>();
            SimpleIoc.Default.Register<NowaPozyczkaViewModel>();
            SimpleIoc.Default.Register<SplataPozyczkiViewModel>();
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
        public SplataPozyczkiViewModel SplataPozyczkiVM {
            get            {
                return SimpleIoc.Default.GetInstance<SplataPozyczkiViewModel>();
            }
        }
        public OperacjeViewModel OperacjeVM {
            get {
                return SimpleIoc.Default.GetInstance<OperacjeViewModel>();
            }
        }
        #endregion
        
        public static void Cleanup() {
            // TODO Clear the ViewModels
        }
    }
}