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
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace Fundusz2.ViewModel {
    public class PozyczkiViewModel {

        #region POLA I WŁASNOŚCI
        public ObservableCollection<PozyczkaDTO> ListaPozyczek = new ObservableCollection<PozyczkaDTO>();
        public CollectionViewSource ViewSource { get; private set; } = new CollectionViewSource();
        #endregion

        #region POLECENIA
        public ICommand PolecenieNowaPozyczka { get; private set; }
        public ICommand PolecenieSplacPozyczke { get; private set; }
        #endregion

        #region KONSTRUKTOR
        public PozyczkiViewModel() {
            ViewSource.Source = ListaPozyczek;
            PolecenieSplacPozyczke = new RelayCommand<object>(o => SplataPozyczki(o), o => PolecenieSplacCanExecute(o));
            //
            Odswiez();
        }
        #endregion

        #region METODY
        private bool PolecenieSplacCanExecute(object o) {
            return o is PozyczkaDTO ? true : false;
        }
        private void SplataPozyczki(object o) {
            var pozyczka = o as PozyczkaDTO;
            MessageBox.Show(pozyczka.NumerPozyczki);
        }
        private void Odswiez() {
            ListaPozyczek.Clear();
            var pozyczki = new List<Pozyczka>();
            if (BazaDanych.TrybProj) {
                pozyczki.Add(new Pozyczka { NrPozyczki = "1", PostFix = "/POZ/2019", Pozyczkobiorca = new Uczestnik { ImieNazwisko = "MichalD", EmailTelefon = "tel1" }, DataWyplaty=DateTime.Today, KwotaCalkowita = 100.00m, PozostaloDoSplaty = 50.00m });
                pozyczki.Add(new Pozyczka { NrPozyczki = "2", PostFix = "/POZ/2019", Pozyczkobiorca = new Uczestnik { ImieNazwisko = "JakasKryska", EmailTelefon = "tel2" }, DataWyplaty = DateTime.Today, KwotaCalkowita = 200.00m, PozostaloDoSplaty = 150.00m });
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
