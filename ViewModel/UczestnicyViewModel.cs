using Fundusz2.Model;
using Fundusz2.Model.DTO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Fundusz2.ViewModel {
    public class UczestnicyViewModel : ViewModelBase {

        #region POLA I WŁAŚCIWOŚCI
        public ObservableCollection<UczestnikDTO> ListaUczestnikow = new ObservableCollection<UczestnikDTO>();
        public CollectionViewSource ViewSource { get; private set; } = new CollectionViewSource();
        #endregion

        #region POLECENIA
        public ICommand PolecenieDodajUczestnika { get; private set; }
        #endregion

        #region KONSTRUKTOR
        public UczestnicyViewModel() {
            PolecenieDodajUczestnika = new RelayCommand(() => DodajUczestnika());
            ViewSource.Source = ListaUczestnikow;
            WczytajUczestnikow();
        }
        #endregion

        #region METODY
        private void WczytajUczestnikow() {
            
            var listaUczestnikow = BazaDanych.ObiektBazyDanych.Uczestnicy.ToList();
            foreach (var item in listaUczestnikow.Select(a => new UczestnikDTO(a))) {
                ListaUczestnikow.Add(item);
            }
        }
        private void DodajUczestnika() {
            MessageBox.Show("Jeszcze nie gotowe :(");
        }
        #endregion
    }
}
