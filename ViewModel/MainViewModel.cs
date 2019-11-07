using GalaSoft.MvvmLight;
using Fundusz2.Model;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Fundusz2.ViewModel {
    public class MainViewModel : ViewModelBase {

        #region POLA I W£AŒCIWOŒCI
        private readonly Fundusz dane = FunduszDAL.Wczytaj();
        public decimal Gotowka {
            get => dane.Gotowka;
            set {
                dane.Gotowka = value;
                RaisePropertyChanged(nameof(Gotowka));
                ZapiszDaneFunduszu();
            }
        }
        public decimal Pozyczki {
            get => dane.Pozyczki;
            set {
                dane.Pozyczki = value;
                RaisePropertyChanged(nameof(Pozyczki));
                ZapiszDaneFunduszu();
            }
        }
        public decimal Lokaty {
            get => dane.Lokaty;
            set {
                dane.Lokaty = value;
                RaisePropertyChanged(nameof(Lokaty));
                ZapiszDaneFunduszu();
            }
        }
        public decimal InneInwestycje {
            get => dane.InneInwestycje;
            set {
                dane.InneInwestycje = value;
                RaisePropertyChanged(nameof(InneInwestycje));
                ZapiszDaneFunduszu();
            }
        }
        #endregion

        #region POLECENIA
        // public ICommand PolecenieOtworzUczestnicy { get; private set; } <- przyk³ad polecenia
        #endregion

        #region KONSTRUKTOR
        public MainViewModel() {
            // PolecenieOtworzUczestnicy = new RelayCommand(() => widokUczestnicy.ShowDialog()); <- jako œci¹ga - przyk³ad polecenia
            //var dane = FunduszDAL.Wczytaj();
            //Gotowka = dane.Gotowka;
            //Pozyczki = dane.Pozyczki;
            //Lokaty = dane.Lokaty;
            //InneInwestycje = dane.InneInwestycje;
        }
        #endregion

        #region METODY
        private void ZapiszDaneFunduszu() {
            FunduszDAL.Zapisz(dane);
        }
        #endregion
    }
}