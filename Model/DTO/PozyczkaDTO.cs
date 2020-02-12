using GalaSoft.MvvmLight;

namespace Fundusz2.Model.DTO {
    public class PozyczkaDTO : ViewModelBase {

        #region DANE Z BAZY
        private readonly Pozyczka pozyczkaDB;
        #endregion

        #region KONSTRUKTOR
        public PozyczkaDTO(Pozyczka pozyczka) {
            pozyczkaDB = pozyczka;
        }
        #endregion

        #region PROPERTIES
        public string NumerPozyczki => pozyczkaDB.NrPozyczki.ToString() + "/POZ/" + pozyczkaDB.PostFix.ToString();
        public string Pozyczkobiorca => pozyczkaDB.Pozyczkobiorca?.ImieNazwisko;
        public string DataWyplaty => pozyczkaDB.DataWyplaty.ToShortDateString();
        public string KwotaCalkowita => pozyczkaDB.KwotaCalkowita.ToString() + " zł";
        public string Uwagi => pozyczkaDB.Uwagi;
        public decimal KwotaPozostala { 
            get => pozyczkaDB.PozostaloDoSplaty;
            set { 
                pozyczkaDB.PozostaloDoSplaty = value;
                RaisePropertyChanged(nameof(KwotaPozostala));
                BazaDanych.ZapiszZmianyWBazie();
            }
        }
        public bool Splacona {
            get => pozyczkaDB.Splacona;
            set {
                pozyczkaDB.Splacona = value;
                BazaDanych.ZapiszZmianyWBazie();
            }
        }
        #endregion
    }
}
