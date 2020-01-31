using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Fundusz2.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace Fundusz2.ViewModel {
    public class SplataPozyczkiViewModel {

        public ICommand PolecenieZatwierdz { get; private set; }

        public SplataPozyczkiViewModel() {
            PolecenieZatwierdz = new RelayCommand<object>(o => ZatwierdzSplate(o), o => ZatwierdzCanExecute(o));
        }

        private bool ZatwierdzCanExecute(object o) {
            return decimal.TryParse((string)o, out _); // podkreślenie ("_") oznacza że wynik jest niepotrzebny
        }
        private void ZatwierdzSplate(object o) {
            var kwotaSplaty = decimal.Parse((string)o);
            Messenger.Default.Send<Komunikator, PozyczkiViewModel>(new Komunikator { Typ = Operacja.TypOperacji.SplataPozyczki, Wartosc = kwotaSplaty });
            Tools.ZamknijOkno("Spłata Pożyczki");
        }
    }
}
