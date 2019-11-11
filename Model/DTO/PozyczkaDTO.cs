using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.Model.DTO {
    internal class PozyczkaDTO {

        #region DANE Z BAZY
        private readonly Pozyczka pozyczkaDB;
        #endregion

        #region KONSTRUKTOR
        public PozyczkaDTO(Pozyczka pozyczka) {
            pozyczkaDB = pozyczka;
        }
        #endregion
    }
}
