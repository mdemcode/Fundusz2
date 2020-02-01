using Fundusz2.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Fundusz2.ViewModel {
    public class OperacjeViewModel : ViewModelBase {

        #region POLA i PROPERTIES
        public ObservableCollection<Operacja> ListaOperacji = new ObservableCollection<Operacja>();
        public CollectionViewSource ViewSource { get; private set; } = new CollectionViewSource();
        #endregion

        #region KONSTRUKTOR
        public OperacjeViewModel() {
            ViewSource.Source = ListaOperacji;
            BazaDanych.ObiektBazyDanych.Operacje.OrderByDescending(x => x.Data).ToList().ForEach(x => ListaOperacji.Add(x));
        }
        #endregion
    }
}
