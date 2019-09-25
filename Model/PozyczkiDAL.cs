using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.Model {
    public static class PozyczkiDAL {
        public static ObservableCollection<Pozyczka> Wczytaj() {
            var pozyczki = new ObservableCollection<Pozyczka>();
            if (FunduszDAL.trybProj) {
                //if (Properties.Settings.Default._proj) {
                pozyczki.Add(new Pozyczka { NrPozyczki = "1", PostFix="2019", Pozyczkobiorca=new Uczestnik {ImieNazwisko="MichalD" }, });
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
