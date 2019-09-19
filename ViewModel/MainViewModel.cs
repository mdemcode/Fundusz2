using GalaSoft.MvvmLight;
using Fundusz2.View; //TODO -docelowo tu nie moze byc
using Fundusz2.Model;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

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

        #region POLECENIA
        public ICommand PolecenieTestowe {
            get;
            private set;
        }
        private void Testowe() {
            var test1 = new UczestnicyView();
            test1.ShowDialog();
        }
        #endregion

        #region KONSTRUKTOR
        public MainViewModel() {
            PolecenieTestowe = new RelayCommand(Testowe);
            var dane = FunduszDAL.Wczytaj();
            Gotowka = dane.Gotowka;
            Pozyczki = dane.Pozyczki;
            Lokaty = dane.Lokaty;
            InneInwestycje = dane.InneInwestycje;
        }
        #endregion

        #region METODY
        private void ZapiszDaneFunduszu() {
            var noweDane = new Fundusz() {
                Gotowka = _gotowka,
                Pozyczki = _pozyczki,
                Lokaty = _lokaty,
                InneInwestycje = _inwestycje
            };
            FunduszDAL.Zapisz(noweDane);
        }
        #endregion
    }
}