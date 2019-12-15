using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

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
        public string Pozyczkobiorca => pozyczkaDB.Pozyczkobiorca.ImieNazwisko;
        public string DataWyplaty => pozyczkaDB.DataWyplaty.ToShortDateString();
        public string KwotaCalkowita => pozyczkaDB.KwotaCalkowita.ToString() + " zł";
        public decimal KwotaPozostala { 
            get => pozyczkaDB.PozostaloDoSplaty;
            set { 
                pozyczkaDB.PozostaloDoSplaty = value;
                RaisePropertyChanged(nameof(KwotaPozostala));
                BazaDanych.ZapiszIOdswiez(TypDanych.pozyczki);
            }
        }
        #endregion
    }
}
