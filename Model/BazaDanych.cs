namespace Fundusz2.Model {
    public sealed class BazaDanych {
        private static BazaFundusz2 obiekt_bazy_danych = null;
        private static readonly object padlock = new object();
        BazaDanych() {
        }
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
    }
}
