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
            PolecenieNowaPozyczka = new RelayCommand(() => NowaPozyczka());
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
            //var kwota_splaty = 20m;
            ////
            //pozyczka.KwotaPozostala -= kwota_splaty;
        }
        private void NowaPozyczka() {
            var okno = (Window)Activator.CreateInstance(Type.GetType("Fundusz2.View.NowaPozyczkaView"));
            okno.ShowDialog();
            Odswiez();
        }
        private void Odswiez() {
            ListaPozyczek.Clear();
            BazaDanych.ListaPozyczekDB.OrderBy(x => x.NrPozyczki).ToList()
                                      .ForEach(x => ListaPozyczek.Add(new PozyczkaDTO(x)));
        }
        #endregion
    }
}
