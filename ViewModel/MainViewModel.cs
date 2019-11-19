using GalaSoft.MvvmLight;
using Fundusz2.Model;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using System;

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
        public ICommand PolecenieUzupelnijBaze { get; private set; }
        #endregion

        #region KONSTRUKTOR
        public MainViewModel() {
            if (BazaDanych.ObiektBazyDanych.FunduszMain.Any()) {
                daneFunduszu = BazaDanych.ObiektBazyDanych.FunduszMain.First();
            }
            else {
                daneFunduszu = new Fundusz { Gotowka = 0, Lokaty = 0, Pozyczki = 0, InneInwestycje = 0 };
                BazaDanych.ObiektBazyDanych.FunduszMain.Add(daneFunduszu);
                BazaDanych.ZapiszZmiany();
            }
            PolecenieTestowe = new RelayCommand(() => Testowa()); // <- przyk³ad polecenia
            PolecenieUzupelnijBaze = new RelayCommand(() => FillTheBase());
        }
        #endregion

        #region METODY
        private void Testowa() {
            Gotowka = 10.00m;
            Pozyczki = 20.00m;
            Lokaty = 30.00m;
            InneInwestycje = 40.00m;
        }
        private void FillTheBase() {
            //var listaUczestnikow = BazaDanych.ObiektBazyDanych.Uczestnicy.ToList();
            if (BazaDanych.ObiektBazyDanych.Uczestnicy.Any()) return;
            MessageBox.Show("Uzupe³niam bazê danych");
            BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko="Anna i Micha³ Demiañczuk", DataPrzystapienia=DateTime.Today, EmailTelefon="607783433", Udzial = 0.64m, Wklad = 16000m, Id = Guid.NewGuid() }); //
            BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko = "Dominik Demiañczuk", DataPrzystapienia = DateTime.Today, EmailTelefon = "tel. Domka", Udzial = 0.20m, Wklad = 5000m, Id = Guid.NewGuid() });
            BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko = "Jakub Demiañczuk", DataPrzystapienia = DateTime.Today, EmailTelefon = "tel. Kuby", Udzial = 0.16m, Wklad = 4000m, Id = Guid.NewGuid() });
            BazaDanych.ZapiszZmiany();
        }
        #endregion
    }
}