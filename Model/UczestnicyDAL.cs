using System;
using System.Collections.ObjectModel;

namespace Fundusz2.Model
{
    public static class UczestnicyDAL {
        public static ObservableCollection<Uczestnik> Wczytaj() {
            var uczestnicy = new ObservableCollection<Uczestnik>();
            if (FunduszDAL.trybProj) { 
            //if (Properties.Settings.Default._proj) {
                uczestnicy.Add(new Uczestnik { ImieNazwisko = "MichalD", EmailTelefon = "607798", DataPrzystapienia = DateTime.Now });
                uczestnicy.Add(new Uczestnik { ImieNazwisko = "Stasiek", EmailTelefon = "999", DataPrzystapienia = DateTime.Today.Date });
                uczestnicy.Add(new Uczestnik { ImieNazwisko = "Krycha", EmailTelefon = "997", DataPrzystapienia = DateTime.Today });
            }
            else {
                //TODO uczestnicy = Wczytaj dane z bazy uczestnicy
            }
            return uczestnicy;
        }
        public static void Dodaj(Uczestnik nowyUczestnik) {

        }
    }
}
