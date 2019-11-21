using Fundusz2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.ViewModel {
    public class NowaPozyczkaViewModel {

        #region POLA I PROPERTIES
        public IList<Uczestnik> Uczestnicy => BazaDanych.ObiektBazyDanych.Uczestnicy.ToList(); // .Select(x => x.ImieNazwisko).ToList();
        private readonly int rok;
        private readonly int nrPozyczki;
        public string NumerPozyczki => nrPozyczki + "/POZ/" + rok;
        public int Kwota { get; set; }
        #endregion

        #region KONSTRUKTOR
        public NowaPozyczkaViewModel() {
            rok = DateTime.Now.Year;
            nrPozyczki = UstawNumerPozyczki();
        }
        #endregion

        #region METODY
        private int UstawNumerPozyczki() {
            var ostatniNumerPozyczki = BazaDanych.ObiektBazyDanych.Pozyczki?.Where(x => x.PostFix == rok)?.Max(x => x.NrPozyczki);
            return ostatniNumerPozyczki != null ? (int)ostatniNumerPozyczki + 1 : 1;
        }
        #endregion
    }
}
