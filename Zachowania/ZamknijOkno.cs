using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Fundusz2.Zachowania {
    public class ZamknijOkno : Behavior<Window> {
        public static readonly DependencyProperty PrzyciskProperty =
            DependencyProperty.Register(
                "Przycisk",
                typeof(Button),
                typeof(ZamknijOkno),
                new PropertyMetadata(null, PrzyciskZmieniony)
                );
        public Button Przycisk {
            get { return (Button)GetValue(PrzyciskProperty); }
            set { SetValue(PrzyciskProperty, value); }
        }
        private static void PrzyciskZmieniony(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            Window okno = (d as ZamknijOkno).AssociatedObject;
            //RoutedEventHandler button_Click = (object sender, RoutedEventArgs _e) => { okno.Close(); };
            void button_Click(object sender, RoutedEventArgs _e) { okno.Close(); }
            if (e.OldValue != null) ((Button)e.OldValue).Click -= button_Click;
            if (e.NewValue != null) ((Button)e.NewValue).Click += button_Click;
        }
    }
}
