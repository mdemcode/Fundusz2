using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Fundusz2.Model {
    public static class UczestnicyDAL {
        public static IList<Uczestnik> Wczytaj() {
            return BazaDanych.Obiekt_Bazy_Danych.Uczestnicy.ToList();
                //using (var baza = new BazaFundusz2()) {
                //    return baza.Uczestnicy.ToList();
                //}
        }
        public static void Dodaj(Uczestnik nowyUczestnik) {
            BazaDanych.Obiekt_Bazy_Danych.Uczestnicy.Add(nowyUczestnik);
            BazaDanych.Obiekt_Bazy_Danych.SaveChanges();
            //using (var baza = new BazaFundusz2()) {
            //    baza.Uczestnicy.Add(nowyUczestnik);
            //    baza.SaveChanges();
            //}
        }
    }
}
