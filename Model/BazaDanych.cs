using GalaSoft.MvvmLight;
using System;
using System.Linq;
using System.Windows;

namespace Fundusz2.Model {
    public sealed class BazaDanych { // : ViewModelBase
        //
        //public static bool TrybProj => Debugger.IsAttached ? true : false;
        //
        #region POLA PRYWATNE
        private static BazaFundusz2 obiektBazyDanych = null;
        private static Fundusz funduszDB = null;
        #endregion
        //
        #region PROPERTIES (public)
        public static BazaFundusz2 ObiektBazyDanych {
            get {
                var padlock = new object();
                lock (padlock) {
                    if (obiektBazyDanych == null) obiektBazyDanych = new BazaFundusz2();
                    return obiektBazyDanych;
                }
            }
        }
        public static Fundusz FunduszDB {
            get {
                var padlock = new object();
                lock (padlock) {
                    if (funduszDB == null) funduszDB = ObiektBazyDanych.FunduszMain.First();
                    return funduszDB;
                }
            }
            set {
                funduszDB = value;
                ZapiszZmianyWBazie();
            }
        }
        #endregion
        //
        BazaDanych() {} //PUSTY KONSTRUKTOR
        //
        #region METODY
        // <<<<< Aktywacja w App.g.cs w metodzie Main[] >>>>>
        //public static void Aktywuj() {
        //    var padlock = new object();
        //    lock (padlock) {
        //        if (obiektBazyDanych == null) {
        //            obiektBazyDanych = new BazaFundusz2();
        //        }
        //    }
        //}
        public static void ZapiszZmianyWBazie() {
            if (ObiektBazyDanych == null) return;
            try {
                obiektBazyDanych.SaveChanges();
            }
            catch (Exception e) {
                MessageBox.Show("Błąd zapisu do bazy danych!\n\n" + e.Message);
            }
        }
        //public static void ZapisOdczyt(bool zapis, params TypDanych[] ktore_dane_odswiezyc) {
        //    //if (ObiektBazyDanych == null) {
        //    //    MessageBox.Show("To nie powinno się wydarzyć???");
        //    //    return;
        //    //}
        //    if (zapis) ZapiszZmianyWBazie();
        //    foreach (var dane in ktore_dane_odswiezyc) {
        //        switch (dane) {
        //            case TypDanych.fundusz:
        //                funduszDB = null;
        //                funduszDB = ObiektBazyDanych.FunduszMain.First();
        //                break;
        //            case TypDanych.uczestnicy:
        //                ListaUczestnikowDB?.Clear();
        //                listaUczestnikowDB = ObiektBazyDanych.Uczestnicy.ToList();
        //                break;
        //            case TypDanych.pozyczki:
        //                listaPozyczekDB?.Clear();
        //                listaPozyczekDB = ObiektBazyDanych.Pozyczki.Include("Pozyczkobiorca").ToList();
        //                break;
        //            case TypDanych.operacje:

        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
        #endregion
    }
    //public enum TypDanych {
    //    fundusz,
    //    uczestnicy,
    //    pozyczki,
    //    operacje,
    //    inwestycje
    //}
}
