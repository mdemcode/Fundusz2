using Fundusz2.Model;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fundusz2.ViewModel {
    public class NowaPozyczkaViewModel {

        #region POLA I PROPERTIES
        public IList<Uczestnik> Uczestnicy { get; } = new List<Uczestnik>();
        private readonly int rok;
        private int nrPozyczki;
        public string NumerPozyczki => nrPozyczki + "/POZ/" + rok;
        public Uczestnik Pozyczkobiorca_ { get; set; }
        public int Kwota_ { get; set; }
        public DateTime DataWyplaty_ { get; set; }
        public string Uwagi_ { get; set; }
        //
        public ICommand PolecenieZatwierdz { get; private set; }
        #endregion

        #region KONSTRUKTOR
        public NowaPozyczkaViewModel() {
            rok = DateTime.Now.Year;
            nrPozyczki = UstawNumerPozyczki();
            PolecenieZatwierdz = new RelayCommand(() => ZatwierdzPozyczke());
            DataWyplaty_ = DateTime.Now;
            Uczestnicy = BazaDanych.ObiektBazyDanych.Uczestnicy.ToList();
        }
        #endregion

        #region METODY
        private int UstawNumerPozyczki() {
            var ostatniNumerPozyczki = BazaDanych.ObiektBazyDanych.Pozyczki?.Where(x => x.PostFix == rok)?.Max(x => x.NrPozyczki);
            return ostatniNumerPozyczki != null ? (int)ostatniNumerPozyczki + 1 : 1;
        }
        private void ZatwierdzPozyczke() {
            MessageBox.Show($"{NumerPozyczki} \n {Pozyczkobiorca_.ImieNazwisko} \n {Kwota_} \n {DataWyplaty_.ToShortDateString()}");
            try { 
                var nowaPozyczka = new Pozyczka {
                    Id = Guid.NewGuid(),
                    NrPozyczki = nrPozyczki,
                    PostFix = rok,
                    Pozyczkobiorca = Pozyczkobiorca_,
                    KwotaCalkowita = Kwota_,
                    DataWyplaty = DataWyplaty_,
                    PozostaloDoSplaty = Kwota_,
                    Splacona = false, 
                    Uwagi = Uwagi_
                };
                BazaDanych.ObiektBazyDanych.Pozyczki.Add(nowaPozyczka);
                BazaDanych.ZapiszZmianyWBazie();

            }
            catch {
                MessageBox.Show("Błąd zapisu do bazy danych!");
            }
            finally {
                nrPozyczki++;
                Kwota_ = 0;
                Uwagi_ = "";
                Pozyczkobiorca_ = null;
            }
        }
        #endregion
    }
}
