using System;
using System.Globalization;
using System.Windows.Data;

namespace Fundusz2.Dodatki {

    public class DecimalToStringWalutaKonwerter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var zaokr = Math.Round((decimal)value, 2);
            return zaokr.ToString() + " zł";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    
    public class SumaSkladowychKonwerter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            var gotowka = (decimal)values[0];
            var pozyczki = (decimal)values[1];
            var lokaty = (decimal)values[2];
            var inne = (decimal)values[3];
            return (gotowka + pozyczki + lokaty + inne).ToString() + " zł";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
   
    public class NrLokatyKonwerter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            return (string)values[0] + "/LOK/" + (string)values[1];
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class DataZamknLokatyKonwerter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            return ((DateTime)values[0]).AddDays((int)values[1]).ToShortDateString();
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    //todo -> DO WYWALENIA
    public class NrPozyczkiKonwerter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            var nr = values[0].ToString();
            var postfix = values[1].ToString();
            return nr + "/" + postfix;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
