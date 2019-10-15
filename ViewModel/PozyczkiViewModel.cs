using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fundusz2.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.ViewModel {
    public class PozyczkiViewModel {

        public ObservableCollection<Pozyczka> ListaPozyczek { get; private set; }

        public PozyczkiViewModel() {
            ListaPozyczek = PozyczkiDAL.Wczytaj();

        }
    }
}
