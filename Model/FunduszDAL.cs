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
                dane.Gotowka = 10m;
                dane.Pozyczki = 20m;
                dane.Lokaty = 30m;
                dane.InneInwestycje = 40m;
                dane.MiesiacNaliczeniaOdsetek = DateTime.Now.Month;
            }
            else {
                var fundusz_ = BazaDanych.Obiekt_Bazy_Danych.FunduszMain;
                dane = fundusz_.FirstOrDefault();
            }
            return dane;
        }
        public static void Zapisz(Fundusz noweDane) {
            //TODO (zapisz dane do bazy)
        }
    }
}
