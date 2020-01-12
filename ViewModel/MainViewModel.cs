using GalaSoft.MvvmLight;
using Fundusz2.Model;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using System;
using GalaSoft.MvvmLight.Messaging;

namespace Fundusz2.ViewModel {
    public class MainViewModel : ViewModelBase {

        #region POLA I W£AŒCIWOŒCI
        public decimal Gotowka {
            get => BazaDanych.FunduszDB.Gotowka;
            set {
                BazaDanych.FunduszDB.Gotowka = value;
                RaisePropertyChanged(nameof(Gotowka));
                BazaDanych.ZapiszZmianyWBazie();
            }
        }
        public decimal Pozyczki {
            get => BazaDanych.FunduszDB.Pozyczki;
            set
            {
                BazaDanych.FunduszDB.Pozyczki = value;
                RaisePropertyChanged(nameof(Pozyczki));
                BazaDanych.ZapiszZmianyWBazie();
            }
        }
        public decimal Lokaty {
            get => BazaDanych.FunduszDB.Lokaty;
            set {
                BazaDanych.FunduszDB.Lokaty = value;
                RaisePropertyChanged(nameof(Lokaty));
                BazaDanych.ZapiszZmianyWBazie();
            }
        }
        public decimal InneInwestycje {
            get => BazaDanych.FunduszDB.InneInwestycje;
            set {
                BazaDanych.FunduszDB.InneInwestycje = value;
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
            PolecenieTestowe = new RelayCommand(() => Testowa()); // <- przyk³ad polecenia
            PolecenieUzupelnijBaze = new RelayCommand(() => FillTheBase());
            //Messenger:
            Messenger.Default.Register<Komunikator>(this, WykonajKomunikat);
        }
        #endregion

        #region METODY
        private void Testowa() {
            
        }
        private void WykonajKomunikat(Komunikator komunikat) {
            switch (komunikat.Typ) {
                case Operacja.TypOperacji.FunduszZalozycielski:
                    break;
                case Operacja.TypOperacji.SplataPozyczki:
                    break;
                case Operacja.TypOperacji.PrzychodZLokaty:
                    break;
                case Operacja.TypOperacji.PrzychodInny:
                    break;
                case Operacja.TypOperacji.WyplataPozyczki:
                    Pozyczki += komunikat.Wartosc;
                    Gotowka -= komunikat.Wartosc;
                    break;
                case Operacja.TypOperacji.RozchodNaLokate:
                    break;
                case Operacja.TypOperacji.RozchodInny:
                    break;
                default:
                    break;
            }
        }
        private void FillTheBase() {
            if (BazaDanych.ObiektBazyDanych.Uczestnicy.Any()) return;
            MessageBox.Show("Uzupe³niam bazê danych");
            BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko="Anna i Micha³ Demiañczuk", DataPrzystapienia=DateTime.Today, Telefon="607783433", Udzial = 0.64m, Wklad = 16000m, Id = Guid.NewGuid() }); //
            BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko = "Dominik Demiañczuk", DataPrzystapienia = DateTime.Today, Telefon = "511911162", Udzial = 0.20m, Wklad = 5000m, Id = Guid.NewGuid() });
            BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko = "Jakub Demiañczuk", DataPrzystapienia = DateTime.Today, Telefon = "514380888", Udzial = 0.16m, Wklad = 4000m, Id = Guid.NewGuid() });
            BazaDanych.ZapiszZmianyWBazie();
        }
        #endregion
    }
}