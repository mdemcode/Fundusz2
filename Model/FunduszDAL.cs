using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fundusz2.Model {
    public static class FunduszDAL {
        public static bool trybProj = true;
        public static Fundusz Wczytaj() {
            var dane = new Fundusz();
            if (trybProj) { 
            //if (Properties.Settings.Default._proj) {
                dane.Gotowka = 100m;
                dane.Pozyczki = 200m;
                dane.Lokaty = 300m;
                dane.InneInwestycje = 400m;
            }
            else {
                //TODO dane = (wczytane z bazy)
            }
            return dane;
        }
        public static void Zapisz(Fundusz noweDane) {
            //TODO (zapisz dane do bazy)
        }
    }
}
