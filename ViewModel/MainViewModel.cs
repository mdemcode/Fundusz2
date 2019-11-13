using GalaSoft.MvvmLight;
using Fundusz2.Model;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Linq;

namespace Fundusz2.ViewModel {
    public class MainViewModel : ViewModelBase {

        #region POLA I W£AŒCIWOŒCI
        private readonly Fundusz daneFunduszu;
        public decimal Gotowka {
            get => daneFunduszu.Gotowka;
            set {
                daneFunduszu.Gotowka = value;
                RaisePropertyChanged(nameof(Gotowka));
                BazaDanych.ZapiszZmiany();
            }
        }
        public decimal Pozyczki {
            get => daneFunduszu.Pozyczki;
            set {
                daneFunduszu.Pozyczki = value;
                RaisePropertyChanged(nameof(Pozyczki));
                BazaDanych.ZapiszZmiany();
            }
        }
        public decimal Lokaty {
            get => daneFunduszu.Lokaty;
            set {
                daneFunduszu.Lokaty = value;
                RaisePropertyChanged(nameof(Lokaty));
                BazaDanych.ZapiszZmiany();
            }
        }
        public decimal InneInwestycje {
            get => daneFunduszu.InneInwestycje;
            set {
                daneFunduszu.InneInwestycje = value;
                RaisePropertyChanged(nameof(InneInwestycje));
                BazaDanych.ZapiszZmiany();
            }
        }
        #endregion

        #region POLECENIA
        public ICommand PolecenieTestowe { get; private set; } // <- przyk³ad polecenia
        #endregion

        #region KONSTRUKTOR
        public MainViewModel() {
            daneFunduszu = Wczytaj();
            PolecenieTestowe = new RelayCommand(() => Testowa()); // <- przyk³ad polecenia
        }
        #endregion

        #region METODY
        private Fundusz Wczytaj() {
            return BazaDanych.TrybProj ?
                   new Fundusz() { Gotowka = 1.00m, Lokaty = 1.00m, Pozyczki = 1.00m, InneInwestycje = 1.00m }
                   : BazaDanych.ObiektBazyDanych.FunduszMain.First();
        }
        private void Testowa() {
            Gotowka = 10.00m;
            Pozyczki = 20.00m;
            Lokaty = 30.00m;
            InneInwestycje = 40.00m;
        }
        #endregion
    }
}