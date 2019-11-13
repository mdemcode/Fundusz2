using System.Diagnostics;

namespace Fundusz2.Model {
    public sealed class BazaDanych {
        //
        public static bool TrybProj => Debugger.IsAttached ? true : false;
        private static readonly object padlock = new object();
        private static BazaFundusz2 obiektBazyDanych = null;
        public static BazaFundusz2 ObiektBazyDanych {
            get {
                lock (padlock) {
                    if (obiektBazyDanych == null) {
                        obiektBazyDanych = new BazaFundusz2();
                    }
                    return obiektBazyDanych;
                }
            }
        }
        //
        BazaDanych() {} //PUSTY KONSTRUKTOR
        //
        public static void ZapiszZmiany() {
            ObiektBazyDanych.SaveChanges();
        }
    }
}
