using System.Diagnostics;

namespace Fundusz2.Model {
    public sealed class BazaDanych {
        //
        public static bool TrybProj => Debugger.IsAttached ? true : false;
        private static readonly object padlock = new object();
        private static BazaFundusz2 obiekt_bazy_danych = null;
        public static BazaFundusz2 Obiekt_Bazy_Danych {
            get {
                lock (padlock) {
                    if (obiekt_bazy_danych == null) {
                        obiekt_bazy_danych = new BazaFundusz2();
                    }
                    return obiekt_bazy_danych;
                }
            }
        }
        //
        BazaDanych() {} //PUSTY KONSTRUKTOR
        //
        public static void ZapiszZmiany() {
            obiekt_bazy_danych.SaveChanges();
        }
    }
}
