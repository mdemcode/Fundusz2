using Fundusz2.Model;
using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace Fundusz2.ViewModel
{
    public class TestViewModel : ViewModelBase {
        public IEnumerable<Uczestnik> Uczestnicy { get; private set; }

        #region KONSTRUKTOR
        public TestViewModel() {
            Uczestnicy = UczestnicyDAL.Wczytaj();

        }
        #endregion
    }
}
