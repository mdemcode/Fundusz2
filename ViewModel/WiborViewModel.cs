using Fundusz2.Model;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fundusz2.ViewModel {
    public class WiborViewModel {

        public string AktualnaWartoscWibor { get; private set; }
        public ICommand PolecenieZmien { get; private set; }

        public WiborViewModel() {
            PolecenieZmien = new RelayCommand<object>(o => ZmienWibor(o), o => ZatwierdzCanExecute(o));
            UstawAktualnyWibor();
        }

        private void UstawAktualnyWibor() {
            var zBazy = (double)BazaDanych.ObiektBazyDanych.FunduszMain.First().OprocentowaniePozyczek;
            AktualnaWartoscWibor = ((zBazy * 100) - 1).ToString() + "%";
        }
        private bool ZatwierdzCanExecute(object o) {
            return decimal.TryParse((string)o, out _); // podkreślenie ("_") oznacza że wynik jest niepotrzebny
        }
        private void ZmienWibor(object o) {
            var nowyWibor = decimal.Parse((string)o);
            BazaDanych.ObiektBazyDanych.FunduszMain.First().OprocentowaniePozyczek = (nowyWibor + 1) / 100;
            BazaDanych.ZapiszZmianyWBazie();
            AktualnaWartoscWibor = nowyWibor.ToString() + "%";
            Tools.ZamknijOkno("Wibor3m");
        }
    }
}
