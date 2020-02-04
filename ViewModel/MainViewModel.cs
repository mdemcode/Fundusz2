using GalaSoft.MvvmLight;
using Fundusz2.Model;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using System;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Interactivity;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Threading;

namespace Fundusz2.ViewModel {
    public class MainViewModel : ViewModelBase {

        #region POLA I W£AŒCIWOŒCI
        public decimal Gotowka {
            get {
                try {
                    return BazaDanych.ObiektBazyDanych.FunduszMain.First().Gotowka;
                }
                catch {
                    return 0m;
                }
            }
            set {
                BazaDanych.ObiektBazyDanych.FunduszMain.First().Gotowka = value;
                BazaDanych.ZapiszZmianyWBazie();
                RaisePropertyChanged(nameof(Gotowka));
            }
        }
        public decimal Pozyczki {
            get {
                try {
                    return BazaDanych.ObiektBazyDanych.Pozyczki.Sum(x => x.PozostaloDoSplaty);
                }
                catch {
                    return 0m;
                }
            }
            //set {
            //    BazaDanych.ObiektBazyDanych.FunduszMain.First().Pozyczki = value;
            //    RaisePropertyChanged(nameof(Pozyczki));
            //    BazaDanych.ZapiszZmianyWBazie();
            //}
        }
        public decimal Lokaty { //=> BazaDanych.ObiektBazyDanych.Lokaty?.Sum(x => x.Kwota) ?? 0;
            get {
                try {
                    return BazaDanych.ObiektBazyDanych.Lokaty.Sum(x => x.Kwota); // BazaDanych.ObiektBazyDanych.FunduszMain.First().Lokaty;
                }
                catch {
                    return 0m;
                }
            }
            //set
            //{
            //    BazaDanych.ObiektBazyDanych.FunduszMain.First().Lokaty = value;
            //    RaisePropertyChanged(nameof(Lokaty));
            //    BazaDanych.ZapiszZmianyWBazie();
            //}
        }
        public decimal InneInwestycje { //=> BazaDanych.ObiektBazyDanych.Inwestycje?.Sum(x => x.KwotaPoczatkowa) ?? 0;
            get {
                try {
                    return BazaDanych.ObiektBazyDanych.Inwestycje.Sum(x => x.KwotaPoczatkowa); // BazaDanych.ObiektBazyDanych.FunduszMain.First().InneInwestycje;
                }
                catch {
                    return 0m;
                }
            }
            //set
            //{
            //    BazaDanych.ObiektBazyDanych.FunduszMain.First().InneInwestycje = value;
            //    RaisePropertyChanged(nameof(InneInwestycje));
            //    BazaDanych.ZapiszZmianyWBazie();
            //}
        }
        #endregion

        #region POLECENIA
        public ICommand ZamknijOknoComm { get; private set; }
        public ICommand PolecenieUzupelnijBaze { get; private set; }
        public ICommand TmpCommand { get; private set; }
        #endregion

        #region KONSTRUKTOR
        public MainViewModel() {
            // Polecenia:
            ZamknijOknoComm = new RelayCommand(() => Zamknij());
            PolecenieUzupelnijBaze = new RelayCommand(() => FillTheBase());
            TmpCommand = new RelayCommand(() => TempCommand());
            // Messenger:
            Messenger.Default.Register<Komunikator>(this, WykonajKomunikat);
            //
            if (BazaDanych.ObiektBazyDanych.FunduszMain.Any()) {
                var miesiacNaliczeniaOdsetek = BazaDanych.ObiektBazyDanych.FunduszMain.First().MiesiacNaliczeniaOdsetek;
                if (miesiacNaliczeniaOdsetek != DateTime.Now.Month) {
                    var naliczOdsetki = Task.Factory.StartNew(() => {NaliczOdsetki(miesiacNaliczeniaOdsetek);});
                    naliczOdsetki.Wait();
                }
            }
        }
        #endregion

        #region METODY
        private void NaliczOdsetki(int miesiacNaliczeniaOdsetek) {
            if (!BazaDanych.ObiektBazyDanych.Pozyczki.Any()) {
                BazaDanych.ObiektBazyDanych.FunduszMain.First().MiesiacNaliczeniaOdsetek = DateTime.Now.Month;
                BazaDanych.ZapiszZmianyWBazie();
                return;
            }
            var oprocentowanie = BazaDanych.ObiektBazyDanych.FunduszMain.First().OprocentowaniePozyczek;
            while (miesiacNaliczeniaOdsetek != DateTime.Now.Month) {
                BazaDanych.ObiektBazyDanych.Pozyczki.ToList().ForEach(x => {
                    x.PozostaloDoSplaty += (oprocentowanie/12) * x.PozostaloDoSplaty;
                    var operacja = new Operacja {
                        Id = Guid.NewGuid(),
                        Data = DateTime.Now,
                        Kwota = (oprocentowanie/12) * x.PozostaloDoSplaty,
                        NrElementuOperacji = x.NrPozyczki + "/POZ/" + x.PostFix,
                        Typ = Operacja.TypOperacji.OdsetkiPozyczki,
                        Opis = $"Naliczenie odsetek do pozyczki nr: {x.NrPozyczki}/POZ/{x.PostFix}. Oprocentowanie (w skali roku): {oprocentowanie*100}%."
                    };
                    BazaDanych.ObiektBazyDanych.Operacje.Add(operacja);
                    });
                if (miesiacNaliczeniaOdsetek == 12) miesiacNaliczeniaOdsetek = 1;
                else miesiacNaliczeniaOdsetek++;
            }
            BazaDanych.ObiektBazyDanych.FunduszMain.First().MiesiacNaliczeniaOdsetek = miesiacNaliczeniaOdsetek;
            BazaDanych.ZapiszZmianyWBazie();
            MessageBox.Show($"Naliczono odsetki za miesi¹c {DateTime.Now.Month}");
        }
        private void WykonajKomunikat(Komunikator komunikat) {
            switch (komunikat.Typ) {
                case Operacja.TypOperacji.FunduszZalozycielski:
                    break;
                case Operacja.TypOperacji.SplataPozyczki:
                    Gotowka += komunikat.Wartosc;
                    RaisePropertyChanged(nameof(Pozyczki));
                    break;
                case Operacja.TypOperacji.PrzychodZLokaty:
                    break;
                case Operacja.TypOperacji.PrzychodInny:
                    break;
                case Operacja.TypOperacji.WyplataPozyczki:
                    Gotowka -= komunikat.Wartosc;
                    RaisePropertyChanged(nameof(Pozyczki));
                    break;
                case Operacja.TypOperacji.RozchodNaLokate:
                    Gotowka -= komunikat.Wartosc;
                    RaisePropertyChanged(nameof(Lokaty));
                    break;
                case Operacja.TypOperacji.RozchodInny:
                    break;
                default:
                    break;
            }
        }
        private void Zamknij() {
            Application.Current.Shutdown();
        }
        private void FillTheBase() {
            MessageBox.Show("Uzupe³niam bazê danych...");
            if (!BazaDanych.ObiektBazyDanych.FunduszMain.Any()) {
                BazaDanych.ObiektBazyDanych.FunduszMain.Add(new Fundusz {
                    Gotowka = 25000,
                    OprocentowaniePozyczek = 0.0270m, // UWAGA! Do bazy zapisuje z dok³adnoœci¹ do 0.00 !!!
                    MiesiacNaliczeniaOdsetek = DateTime.Now.Month - 1
                });
                BazaDanych.ZapiszZmianyWBazie();
                RaisePropertyChanged(nameof(Gotowka));
                BazaDanych.ObiektBazyDanych.Operacje.Add(new Operacja { 
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now - TimeSpan.FromDays(700),
                    Kwota = 25000,
                    NrElementuOperacji = "---",
                    Opis = "FUNDUSZ ZA£O¯YCIELSKI",
                    Typ = Operacja.TypOperacji.FunduszZalozycielski
                });
                decimal dopisywaneOdsetki = 934.58m;
                BazaDanych.ObiektBazyDanych.Operacje.Add(new Operacja {
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now,
                    Kwota = dopisywaneOdsetki,
                    NrElementuOperacji = "---",
                    Opis = "Odsetki z porzedniego systemu.",
                    Typ = Operacja.TypOperacji.PrzychodInny
                });
                Gotowka += dopisywaneOdsetki;
            }
            if (!BazaDanych.ObiektBazyDanych.Uczestnicy.Any()) { 
                BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko="Anna i Micha³ Demiañczuk", DataPrzystapienia=DateTime.Today - TimeSpan.FromDays(700), Telefon="607783433", Udzial = 0.64m, Wklad = 16000m, Id = Guid.NewGuid() });
                BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko = "Dominik Demiañczuk", DataPrzystapienia = DateTime.Today - TimeSpan.FromDays(700), Telefon = "511911162", Udzial = 0.20m, Wklad = 5000m, Id = Guid.NewGuid() });
                BazaDanych.ObiektBazyDanych.Uczestnicy.Add(new Uczestnik { ImieNazwisko = "Jakub Demiañczuk", DataPrzystapienia = DateTime.Today - TimeSpan.FromDays(700), Telefon = "514380888", Udzial = 0.16m, Wklad = 4000m, Id = Guid.NewGuid() });
            };
            BazaDanych.ZapiszZmianyWBazie();
            RaisePropertyChanged(nameof(Gotowka));
            MessageBox.Show("...ju¿");
        }
        private void TempCommand () {
            var data = BazaDanych.ObiektBazyDanych.Pozyczki.First().DataWyplaty;
            var nowaData = data.AddDays(35);
            MessageBox.Show(nowaData.ToShortDateString());
        }
        #endregion
    }
}