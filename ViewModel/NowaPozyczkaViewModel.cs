using Fundusz2.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Fundusz2.ViewModel {
    public class NowaPozyczkaViewModel : ViewModelBase {

        #region POLA I PROPERTIES
        public IList<Uczestnik> Uczestnicy { get; } = new List<Uczestnik>();
        private readonly int aktualnyRok;
        private int nrPozyczki;
        public string NumerPozyczki => nrPozyczki + "/POZ/" + aktualnyRok;
        public Uczestnik Pozyczkobiorca_ { get; set; }
        public decimal Kwota_ { get; set; }
        public DateTime DataWyplaty_ { get; set; }
        public string Uwagi_ { get; set; }
        public ICommand PolecenieZatwierdz { get; private set; }
        #endregion

        #region KONSTRUKTOR
        public NowaPozyczkaViewModel() {
            aktualnyRok = DateTime.Now.Year;
            nrPozyczki = UstawNumerPozyczki();
            PolecenieZatwierdz = new RelayCommand(() => ZatwierdzPozyczke());
            DataWyplaty_ = DateTime.Now;
            Uczestnicy = BazaDanych.ObiektBazyDanych.Uczestnicy.ToList();
            Uwagi_ = "...";
        }
        #endregion

        #region METODY
        private int UstawNumerPozyczki() {
            if (!BazaDanych.ObiektBazyDanych.Pozyczki.Any()) return 1;
            return BazaDanych.ObiektBazyDanych.Pozyczki.Where(x => x.PostFix == aktualnyRok).Max(x => x.NrPozyczki) + 1;
        }
        private void ZatwierdzPozyczke() {
            try { 
                var nowaPozyczka = new Pozyczka {
                    Id = Guid.NewGuid(),
                    NrPozyczki = nrPozyczki,
                    PostFix = aktualnyRok,
                    Pozyczkobiorca = Pozyczkobiorca_,
                    KwotaCalkowita = Kwota_,
                    DataWyplaty = DataWyplaty_,
                    PozostaloDoSplaty = Kwota_,
                    Splacona = false, 
                    Uwagi = Uwagi_
                };
                BazaDanych.ObiektBazyDanych.Pozyczki.Add(nowaPozyczka);
                //
                var nowaOperacja = new Operacja {
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now,
                    Typ = Operacja.TypOperacji.WyplataPozyczki,
                    Opis = $"Wypła pożyczki nr {NumerPozyczki}",
                    Kwota = Kwota_,
                    NrElementuOperacji = NumerPozyczki
                };
                BazaDanych.ObiektBazyDanych.Operacje.Add(nowaOperacja);
                //
                BazaDanych.ZapiszZmianyWBazie();
                //
                Messenger.Default.Send<Komunikator, MainViewModel>(new Komunikator { Typ = Operacja.TypOperacji.WyplataPozyczki, Wartosc = Kwota_ });
                Tools.ZamknijOkno("Nowa Pożyczka");
            }
            catch (Exception e) {
                MessageBox.Show($"Błąd zapisu do bazy danych! \n({e.Message})");
            }
            finally {
                nrPozyczki++;
                Kwota_ = 0;
                Uwagi_ = "...";
                Pozyczkobiorca_ = null;
                DataWyplaty_ = DateTime.Now;
            }
        }
        #endregion
    }
}
