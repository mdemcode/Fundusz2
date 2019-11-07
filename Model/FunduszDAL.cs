using System.Linq;

namespace Fundusz2.Model {
    public static class FunduszDAL {
        public static Fundusz Wczytaj() {
            return BazaDanych.Obiekt_Bazy_Danych.FunduszMain.First();
        }
        public static void Zapisz(Fundusz noweDane) {
            //TODO (zapisz dane do bazy)
        }
    }
}
