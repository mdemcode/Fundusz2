using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.Model {
    public static class PozyczkiDAL {
        public static IList<Pozyczka> Wczytaj() {
            var pozyczki = new List<Pozyczka>();
            if (BazaDanych.TrybProj) {
                //if (Properties.Settings.Default._proj) {
                pozyczki.Add(new Pozyczka { NrPozyczki = "1", PostFix="/POZ/2019", Pozyczkobiorca=new Uczestnik {ImieNazwisko="MichalD", EmailTelefon="tel1" }, KwotaCalkowita=100m });
                pozyczki.Add(new Pozyczka { NrPozyczki = "2", PostFix = "/POZ/2019", Pozyczkobiorca = new Uczestnik { ImieNazwisko = "JakasKryska", EmailTelefon="tel2" }, KwotaCalkowita=200m });
            }
            else {
                //TODO dane = (wczytane z bazy)
            }
            return pozyczki;
        }
        public static void Zapisz(Pozyczka noweDane) {
            //TODO (zapisz dane do bazy)
        }

    }
}
