using Fundusz2.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fundusz2.ViewModel {
    public class NowaLokataViewModel : ViewModelBase {

        #region POLA i PROPERTIES
        public string NumerLokaty_ => $"{nowyNrLokaty}/LOK/{DateTime.Now.Year}";
        public int IleDni_ { get; set; }
        public decimal Kwota_ { get; set; }
        public DateTime DataZalozenia_ { get; set; }
        public string Opis_ { get; set; }
        private int nowyNrLokaty;
        public ICommand PolecenieZatwierdz { get; private set; }
        #endregion

        #region KONSTRUKTOR
        public NowaLokataViewModel() {
            NadajNumer();
            RaisePropertyChanged(nameof(NumerLokaty_));
            IleDni_ = 90;
            Kwota_ = 0;
            DataZalozenia_ = DateTime.Today;
            Opis_ = "...";
            PolecenieZatwierdz = new RelayCommand(() => ZatwierdzPozyczke());
        }
        #endregion

        #region METODY
        private void NadajNumer() {
            if (!BazaDanych.ObiektBazyDanych.Lokaty.Any()) {
                nowyNrLokaty = 1;
                return;
            }
            if (BazaDanych.ObiektBazyDanych.Lokaty.Where(x => x.PostFix == DateTime.Now.Year.ToString()).Any()) {
                var numery = BazaDanych.ObiektBazyDanych.Lokaty.Where(x => x.PostFix == DateTime.Now.Year.ToString()).Select(x=>x.NrLokaty).ToList();
                List<int> numeryInt = new List<int>();
                foreach (var numer in numery) {
                    numeryInt.Add(int.Parse(numer));
                }
                nowyNrLokaty = numeryInt.Max() + 1;
            }
            else nowyNrLokaty = 1;
        }
        private void ZatwierdzPozyczke() {
            try {
                var nowaLokata = new Lokata {
                    Id = Guid.NewGuid(),
                    NrLokaty = nowyNrLokaty.ToString(),
                    PostFix = DateTime.Now.Year.ToString(),
                    Opis = Opis_,
                    Kwota = Kwota_,
                    IleDni = IleDni_,
                    DataOtwarcia = DataZalozenia_,
                    Zamknieta = false
                };
                BazaDanych.ObiektBazyDanych.Lokaty.Add(nowaLokata);
                //
                var nowaOperacja = new Operacja {
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now,
                    Typ = Operacja.TypOperacji.RozchodNaLokate,
                    Opis = $"Założenie lokaty nr {nowyNrLokaty}/LOK/{DateTime.Now.Year} (od {DataZalozenia_.ToShortDateString()} na {IleDni_} dni).",
                    Kwota = Kwota_,
                    NrElementuOperacji = $"{nowyNrLokaty}/LOK/{DateTime.Now.Year}"
                };
                BazaDanych.ObiektBazyDanych.Operacje.Add(nowaOperacja);
                //
                BazaDanych.ZapiszZmianyWBazie();
                //
                Messenger.Default.Send<Komunikator, MainViewModel>(new Komunikator { Typ = Operacja.TypOperacji.RozchodNaLokate, Wartosc = Kwota_ });
                Tools.ZamknijOkno("Nowa Lokata");
            }
            catch (Exception e) {
                MessageBox.Show($"Błąd zapisu do bazy danych! \n({e.Message})");
            }
            finally {
                nowyNrLokaty++;
                Kwota_ = 0;
                Opis_ = "...";
                IleDni_ = 90;
                DataZalozenia_ = DateTime.Today;
                RaisePropertyChanged(nameof(NumerLokaty_));
                RaisePropertyChanged(nameof(Kwota_));
                RaisePropertyChanged(nameof(Opis_));
                RaisePropertyChanged(nameof(IleDni_));
                RaisePropertyChanged(nameof(DataZalozenia_));
            }
        }
        #endregion
    }
}
