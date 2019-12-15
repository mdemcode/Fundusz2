using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.Model.DTO {
    public class UczestnikDTO {
        
        #region DANE Z BAZY
        private readonly Uczestnik uczestnikDB;
        #endregion

        #region KONSTRUKTOR
        public UczestnikDTO (Uczestnik uczestnik) {
            uczestnikDB = uczestnik;
        }
        #endregion

        #region PROPERTIES
        public string Nazwa => uczestnikDB.ImieNazwisko;
        public string DataPrzystapienia => uczestnikDB.DataPrzystapienia.ToShortDateString();
        public string Wklad => uczestnikDB.Wklad.ToString() + " zł";
        public string Udzial => (uczestnikDB.Udzial * 100).ToString() + "%";
        public string Kontakt => uczestnikDB.Telefon;
        public string Email => uczestnikDB.Email;
        #endregion

        #region OVERRIDES
        public override string ToString() {
            return uczestnikDB.ImieNazwisko;
        }
        #endregion
    }
}
