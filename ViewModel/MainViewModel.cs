using GalaSoft.MvvmLight;
using Fundusz2.View; //TODO -docelowo tu nie moze byc (ViewModel nie mo¿e nic wiedzieæ o Widoku)
using Fundusz2.Model;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Fundusz2.ViewModel {
    public class MainViewModel : ViewModelBase {

        #region POLA I W£AŒCIWOŒCI
        //private readonly Fundusz daneFunduszu = new Fundusz();
        public decimal Gotowka {
            get {
                return _gotowka;
            }
            set {
                _gotowka = value;
                RaisePropertyChanged(nameof(Gotowka));
                ZapiszDaneFunduszu();
            }
        }
        private decimal _gotowka;
        public decimal Pozyczki {
            get {
                return _pozyczki; ;
            }
            set {
                _pozyczki = value;
                RaisePropertyChanged(nameof(Pozyczki));
                ZapiszDaneFunduszu();
            }
        }
        private decimal _pozyczki;
        public decimal Lokaty {
            get {
                return _lokaty; ;
            }
            set {
                _lokaty = value;
                RaisePropertyChanged(nameof(Lokaty));
                ZapiszDaneFunduszu();
            }
        }
        private decimal _lokaty;
        public decimal InneInwestycje {
            get {
                return _inwestycje; ;
            }
            set {
                _inwestycje = value;
                RaisePropertyChanged(nameof(InneInwestycje));
                ZapiszDaneFunduszu();
            }
        }
        private decimal _inwestycje;
        #endregion

        #region POLECENIA
        public ICommand PolecenieOtworzUczestnicy { get; private set; }
        public ICommand PolecenieTestowe {get; private set; }
        #endregion

        #region KONSTRUKTOR
        public MainViewModel() {
            PolecenieTestowe = new RelayCommand(Testowe);
            PolecenieOtworzUczestnicy = new RelayCommand(OtworzUczestnicy);
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
        private void OtworzUczestnicy() {
            var OknoUczestnicy = new UczestnicyView();
            OknoUczestnicy.ShowDialog();
        }
        private void Testowe() {
            var test1 = new TestView();
            test1.ShowDialog();
        }

        #endregion
    }
}