using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.Model.DTO {
    public class PozyczkaDTO {

        #region DANE Z BAZY
        private readonly Pozyczka pozyczkaDB;
        #endregion

        #region KONSTRUKTOR
        public PozyczkaDTO(Pozyczka pozyczka) {
            pozyczkaDB = pozyczka;
        }
        #endregion

        #region PROPERTIES
        public string NumerPozyczki => pozyczkaDB.NrPozyczki + pozyczkaDB.PostFix;
        public string Pozyczkobiorca => pozyczkaDB.Pozyczkobiorca.ImieNazwisko;
        public string DataWyplaty => pozyczkaDB.DataWyplaty.ToShortDateString();
        public string KwotaCalkowita => pozyczkaDB.KwotaCalkowita.ToString() + " zł";
        public string KwotaPozostala => pozyczkaDB.PozostaloDoSplaty.ToString() + " zł";
        #endregion
    }
}
