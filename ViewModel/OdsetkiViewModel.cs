using Fundusz2.Model;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace Fundusz2.ViewModel {
    public class OdsetkiViewModel {

        public ICommand PolecenieZatwierdz { get; private set; }

        public OdsetkiViewModel() {
            PolecenieZatwierdz = new RelayCommand<object>(o => ZatwierdzOdsetki(o), o => ZatwierdzCanExecute(o));
        }

        private bool ZatwierdzCanExecute(object o) {
            return decimal.TryParse((string)o, out _); // podkreślenie ("_") oznacza że wynik jest niepotrzebny
        }
        private void ZatwierdzOdsetki(object o) {
            var kwotaSplaty = decimal.Parse((string)o);
            Messenger.Default.Send<Komunikator, LokatyViewModel>(new Komunikator { Typ = Operacja.TypOperacji.PrzychodZLokaty, Wartosc = kwotaSplaty });
            Tools.ZamknijOkno("Odsetki z lokaty");
        }
    }
}
