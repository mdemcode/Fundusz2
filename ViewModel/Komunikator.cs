using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.ViewModel {
    public class Komunikator {
        public Model.Operacja.TypOperacji Typ { get; set; }
        public decimal Wartosc { get; set; }
    }
    //public enum TypDanych {
    //    fundusz,
    //    uczestnicy,
    //    pozyczki,
    //    operacje,
    //    inwestycje
    //}
}
