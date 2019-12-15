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
                BazaDanych.ZapiszZmianyWBazie();
            }
        }
        public decimal Pozyczki {
            get => daneFunduszu.Pozyczki;
            set {
                daneFunduszu.Pozyczki = value;
                RaisePropertyChanged(nameof(Pozyczki));
                BazaDanych.ZapiszZmianyWBazie();
            }
        }
        public decimal Lokaty {
            get => daneFunduszu.Lokaty;
            set {
                daneFunduszu.Lokaty = value;
                RaisePropertyChanged(nameof(Lokaty));
                BazaDanych.ZapiszZmianyWBazie();
            }
        }
        public decimal InneInwestycje {
            get => daneFunduszu.InneInwestycje;
            set {
                daneFunduszu.InneInwestycje = value;
                RaisePropertyChanged(nameof(InneInwestycje));
                BazaDanych.ZapiszZmianyWBazie();
            }
        }
        #endregion

        #region POLECENIA
        public ICommand PolecenieTestowe { get; private set; } // <- przyk³ad polecenia
        public ICommand PolecenieUzupelnijBaze { get; private set; }
        #endregion

        #region KONSTRUKTOR
        public MainViewModel() {
            if (BazaDanych.FunduszDB != null) {
                daneFunduszu = BazaDanych.FunduszDB;
            }
            else {
                daneFunduszu = new Fundusz { Gotowka = 0, Lokaty = 0, Pozyczki = 0, InneInwestycje = 0 };
                BazaDanych.ObiektBazyDanych.FunduszMain.Add(daneFunduszu);
                BazaDanych.ZapiszIOdswiez(TypDanych.fundusz);
            }
            PolecenieTestowe = new RelayCommand(() => Testowa()); // <- przyk³ad polecenia
            PolecenieUzupelnijBaze = new RelayCommand(() => FillTheBase());
        }
        #endregion

        #region METODY
        private void Testowa() {
            //Gotowka = 10.00m;
            //Pozyczki = 20.00m;
            //Lokaty = 30.00m;
            //InneInwestycje = 40.00m;
            foreach (var item in BazaDanych.ListaUczestnikowDB) {
                MessageBox.Show(item.ImieNazwisko);
            }
            
        }
        private void FillTheBase() {
            if (BazaDanych.ListaUczestnikowDB.Any()) return;
            MessageBox.Show("Uzupe³niam bazê danych");
            BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko="Anna i Micha³ Demiañczuk", DataPrzystapienia=DateTime.Today, Telefon="607783433", Udzial = 0.64m, Wklad = 16000m, Id = Guid.NewGuid() }); //
            BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko = "Dominik Demiañczuk", DataPrzystapienia = DateTime.Today, Telefon = "511911162", Udzial = 0.20m, Wklad = 5000m, Id = Guid.NewGuid() });
            BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko = "Jakub Demiañczuk", DataPrzystapienia = DateTime.Today, Telefon = "514380888", Udzial = 0.16m, Wklad = 4000m, Id = Guid.NewGuid() });
            BazaDanych.ZapiszIOdswiez(TypDanych.uczestnicy);
        }
        #endregion
    }
}