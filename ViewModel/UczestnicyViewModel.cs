using Fundusz2.Model;
using Fundusz2.Model.DTO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Fundusz2.ViewModel {
    public class UczestnicyViewModel : ViewModelBase {
        public ObservableCollection<UczestnikDTO> ListaUczestnikow = new ObservableCollection<UczestnikDTO>();
        public CollectionViewSource ViewSource { get; private set; }
        public ICommand PolecenieDodajUczestnika { get; private set; }

        #region KONSTRUKTOR
        public UczestnicyViewModel() {
            PolecenieDodajUczestnika = new RelayCommand(() => DodajUczestnika());
            ViewSource = new CollectionViewSource {
                Source = ListaUczestnikow
            };
            var uczest = UczestnicyDAL.Wczytaj().Select(a => new UczestnikDTO(a));
            foreach (var item in uczest) {
                ListaUczestnikow.Add(item);
            }
        }
        #endregion

        #region METODY
        private void DodajUczestnika() {
            MessageBox.Show("Jeszcze nie gotowe :(");
        }
        #endregion
    }
}
