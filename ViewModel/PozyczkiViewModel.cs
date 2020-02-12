using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fundusz2.Model;
using Fundusz2.Model.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace Fundusz2.ViewModel {
    public class PozyczkiViewModel {

        #region POLA I WŁASNOŚCI
        public ObservableCollection<PozyczkaDTO> ListaPozyczek = new ObservableCollection<PozyczkaDTO>();
        public CollectionViewSource ViewSource { get; private set; } = new CollectionViewSource();
        //
        private PozyczkaDTO splacanaPozyczka;
        #endregion

        #region POLECENIA
        public ICommand PolecenieNowaPozyczka { get; private set; }
        public ICommand PolecenieSplacPozyczke { get; private set; }
        #endregion

        #region KONSTRUKTOR
        public PozyczkiViewModel() {
            ViewSource.Source = ListaPozyczek;
            PolecenieSplacPozyczke = new RelayCommand<object>(o => SplataPozyczki(o), o => PolecenieSplacCanExecute(o));
            PolecenieNowaPozyczka = new RelayCommand(() => NowaPozyczka());
            Messenger.Default.Register<Komunikator>(this, WykonajKomunikatSplata);
            splacanaPozyczka = null;
            //
            Odswiez();
        }
        #endregion

        #region METODY
        private bool PolecenieSplacCanExecute(object o) {
            return o is PozyczkaDTO ? true : false;
        }
        private void SplataPozyczki(object o) {
            splacanaPozyczka = o as PozyczkaDTO;
            var okno = (Window)Activator.CreateInstance(Type.GetType("Fundusz2.View.SplataPozyczkiView"));
            okno.ShowDialog();
        }
        private void NowaPozyczka() {
            var okno = (Window)Activator.CreateInstance(Type.GetType("Fundusz2.View.NowaPozyczkaView"));
            okno.ShowDialog();
            Odswiez();
        }
        private void Odswiez() {
            ListaPozyczek.Clear();
            BazaDanych.ObiektBazyDanych.Pozyczki.Include("Pozyczkobiorca").Where(p=>p.Splacona!=true)
                .OrderByDescending(x=>x.PostFix).ThenByDescending(x => x.NrPozyczki).ToList()
                .ForEach(x => ListaPozyczek.Add(new PozyczkaDTO(x)));
        }
        private void WykonajKomunikatSplata(Komunikator komunikat) {
            splacanaPozyczka.KwotaPozostala -= komunikat.Wartosc;
            if (splacanaPozyczka.KwotaPozostala <= 0) splacanaPozyczka.Splacona = true;
            var operacja = new Operacja {
                Id = Guid.NewGuid(),
                Data = DateTime.Now,
                Kwota = komunikat.Wartosc,
                Typ = Operacja.TypOperacji.SplataPozyczki,
                NrElementuOperacji = splacanaPozyczka.NumerPozyczki,
                Opis = $"Spłata raty pożyczki nr {splacanaPozyczka.NumerPozyczki}"
            };
            BazaDanych.ObiektBazyDanych.Operacje.Add(operacja);
            BazaDanych.ZapiszZmianyWBazie();
            MessageBox.Show($"Pozyczka nr {splacanaPozyczka.NumerPozyczki} została pomniejszona o kwotę {komunikat.Wartosc} zł");
            Messenger.Default.Send<Komunikator, MainViewModel>(new Komunikator { Typ = Operacja.TypOperacji.SplataPozyczki, Wartosc = komunikat.Wartosc });
            splacanaPozyczka = null;
            Odswiez();
        }
        #endregion
    }
}
