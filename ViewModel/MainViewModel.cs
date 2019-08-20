using GalaSoft.MvvmLight;
using Fundusz2.Model;
using System.Windows;

namespace Fundusz2.ViewModel {
    public class MainViewModel : ViewModelBase {

        #region POLA
        //private readonly Fundusz daneFunduszu = new Fundusz();
        private decimal _gotowka;
        private decimal _pozyczki;
        private decimal _lokaty;
        private decimal _inwestycje;
        #endregion

        #region W£AŒCIWOŒCI
        public decimal Gotowka {
            get {
                return _gotowka;
            }
            set {
                _gotowka = value;
                RaisePropertyChanged(nameof(Gotowka));
            }
        }
        public decimal Pozyczki {
            get {
                return _pozyczki; ;
            }
            set {
                _pozyczki = value;
                RaisePropertyChanged(nameof(Pozyczki));
            }
        }
        public decimal Lokaty {
            get {
                return _lokaty; ;
            }
            set {
                _lokaty = value;
                RaisePropertyChanged(nameof(Lokaty));
            }
        }
        public decimal InneInwestycje {
            get {
                return _inwestycje; ;
            }
            set {
                _inwestycje = value;
                RaisePropertyChanged(nameof(InneInwestycje));
            }
        }
        #endregion

        #region KONSTRUKTOR
        public MainViewModel() {
            if (IsInDesignMode) {
                Gotowka = 100m;
                MessageBox.Show("Z mainview");
            }
            else {
                // Wczytaj dane z bazy // TODO
            }
        }
        #endregion

        #region METODY
        private void ZapiszDaneFunduszu() {
            //TODO
        }
        #endregion
    }
}