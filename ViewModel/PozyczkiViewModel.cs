using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fundusz2.Model;
using Fundusz2.Model.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Fundusz2.ViewModel {
    public class PozyczkiViewModel {

        #region POLA I WŁASNOŚCI
        public ObservableCollection<PozyczkaDTO> ListaPozyczek = new ObservableCollection<PozyczkaDTO>();
        public CollectionViewSource ViewSource { get; private set; } = new CollectionViewSource();
        #endregion

        #region KONSTRUKTOR
        public PozyczkiViewModel() {
            ViewSource.Source = ListaPozyczek;
            Odswiez();
        }
        #endregion

        #region METODY
        private void Odswiez() {
            var pozyczki = new List<Pozyczka>();
            if (BazaDanych.TrybProj) {
                pozyczki.Add(new Pozyczka { NrPozyczki = "1", PostFix = "/POZ/2019", Pozyczkobiorca = new Uczestnik { ImieNazwisko = "MichalD", EmailTelefon = "tel1" }, KwotaCalkowita = 100m });
                pozyczki.Add(new Pozyczka { NrPozyczki = "2", PostFix = "/POZ/2019", Pozyczkobiorca = new Uczestnik { ImieNazwisko = "JakasKryska", EmailTelefon = "tel2" }, KwotaCalkowita = 200m });
            }
            else {
                //TODO pozyczki = (wczytane z bazy)
            }
            foreach (var item in pozyczki.Select(a => new PozyczkaDTO(a)))
                ListaPozyczek.Add(item);
        }
        #endregion
    }
}
