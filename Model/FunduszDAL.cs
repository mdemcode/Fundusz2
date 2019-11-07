using System.Linq;
using System.Windows;

namespace Fundusz2.Model {
    public static class FunduszDAL {
        public static Fundusz Wczytaj() {
            return BazaDanych.Obiekt_Bazy_Danych.FunduszMain.First();
        }
        public static void Zapisz(Fundusz noweDane) {
            //TODO (zapisz dane do bazy)
            MessageBox.Show($"{noweDane.Gotowka.ToString()}, {noweDane.Pozyczki.ToString()}, {noweDane.Lokaty.ToString()}, {noweDane.InneInwestycje.ToString()}");
        }
    }
}
