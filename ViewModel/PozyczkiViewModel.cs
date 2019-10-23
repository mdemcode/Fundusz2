using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fundusz2.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Fundusz2.ViewModel {
    public class PozyczkiViewModel {
        public ObservableCollection<Pozyczka> ListaPozyczek = new ObservableCollection<Pozyczka>();
        public CollectionViewSource ViewSource { get; private set; }
        public PozyczkiViewModel() {
            ViewSource = new CollectionViewSource {
                Source = ListaPozyczek
            };
            var pozyczki = PozyczkiDAL.Wczytaj();
            foreach (var item in pozyczki) {
                //MessageBox.Show(pozyczki.Count.ToString());
                ListaPozyczek.Add(item);
            }
        }
    }
}
