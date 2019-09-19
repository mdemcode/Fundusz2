using Fundusz2.Model;
using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace Fundusz2.ViewModel {
    public class UczestnicyViewModel : ViewModelBase {
        public IEnumerable<Uczestnik> ListaUczestnikow { get; private set; }

        #region KONSTRUKTOR
        public UczestnicyViewModel() {
            ListaUczestnikow = UczestnicyDAL.Wczytaj();

        }
        #endregion
    }
}
