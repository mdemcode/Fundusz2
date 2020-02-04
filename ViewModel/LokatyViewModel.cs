using Fundusz2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using System.Windows;

namespace Fundusz2.ViewModel {
    public class LokatyViewModel {

        #region POLA I WŁASNOŚCI
        public ObservableCollection<Lokata> ListaLokat = new ObservableCollection<Lokata>();
        public CollectionViewSource ViewSource { get; private set; } = new CollectionViewSource();
        //
        private Lokata zamykanaLokata;
        #endregion

        #region POLECENIA
        public ICommand PolecenieNowaLokata { get; private set; }
        public ICommand PolecenieZamknijLokate { get; private set; }
        #endregion

        #region KONSTRUKTOR
        public LokatyViewModel()
        {
            ViewSource.Source = ListaLokat;
            PolecenieZamknijLokate = new RelayCommand<object>(o => ZamkniecieLokaty(o), o => PolecenieZamknijCanExecute(o));
            PolecenieNowaLokata = new RelayCommand(() => NowaLokata());
            //Messenger.Default.Register<Komunikator>(this, WykonajKomunikatZamknijLokate);
            zamykanaLokata = null;
            //
            Odswiez();
        }
        #endregion

        #region METODY
        private bool PolecenieZamknijCanExecute(object o) {
            return o is Lokata ? true : false;
        }
        private void ZamkniecieLokaty(object o) {
            zamykanaLokata = o as Lokata;
            //
            // -> okienko na wpisanie odsetek
            //
        }
        private void NowaLokata() {
            var okno = (Window)Activator.CreateInstance(Type.GetType("Fundusz2.View.NowaLokataView"));
            okno.ShowDialog();
            Odswiez();
        }
        private void Odswiez() {
            ListaLokat.Clear();
            BazaDanych.ObiektBazyDanych.Lokaty.OrderBy(x => x.DataOtwarcia).ToList().ForEach(x => ListaLokat.Add(x));
        }
        //private void WykonajKomunikatZamknijLokate(Komunikator komunikat)
        //{
        //    splacanaPozyczka.KwotaPozostala -= komunikat.Wartosc;
        //    var operacja = new Operacja
        //    {
        //        Id = Guid.NewGuid(),
        //        Data = DateTime.Now,
        //        Kwota = komunikat.Wartosc,
        //        Typ = Operacja.TypOperacji.SplataPozyczki,
        //        NrElementuOperacji = splacanaPozyczka.NumerPozyczki,
        //        Opis = $"Spłata raty pożyczki nr {splacanaPozyczka.NumerPozyczki}"
        //    };
        //    BazaDanych.ObiektBazyDanych.Operacje.Add(operacja);
        //    BazaDanych.ZapiszZmianyWBazie();
        //    MessageBox.Show($"Pozyczka nr {splacanaPozyczka.NumerPozyczki} została pomniejszona o kwotę {komunikat.Wartosc} zł");
        //    Messenger.Default.Send<Komunikator, MainViewModel>(new Komunikator { Typ = Operacja.TypOperacji.SplataPozyczki, Wartosc = komunikat.Wartosc });
        //    splacanaPozyczka = null;
        //}
        #endregion
    }
}
