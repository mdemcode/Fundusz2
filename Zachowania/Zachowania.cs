using System;
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
            void button_Click(object sender, RoutedEventArgs _e) {
                okno.Close();
                if (okno is MainWindow) Application.Current.Shutdown();
            }
            if (e.OldValue != null) ((Button)e.OldValue).Click -= button_Click;
            if (e.NewValue != null) ((Button)e.NewValue).Click += button_Click;
        }
    }

    //public class OtworzOkno : Behavior<Window> {

    //    public static readonly DependencyProperty PrzyciskProperty =
    //        DependencyProperty.Register(
    //            "Przycisk",
    //            typeof(Button),
    //            typeof(OtworzOkno),
    //            new PropertyMetadata(null, PrzyciskOtwierania)
    //        );
    //    public Button Przycisk {
    //        get { return (Button)GetValue(PrzyciskProperty); }
    //        set { SetValue(PrzyciskProperty, value); }
    //    }
    //    public static readonly DependencyProperty ParametrProperty =
    //        DependencyProperty.Register(
    //            "Parametr",
    //            typeof(string),
    //            typeof(OtworzOkno)
    //        );
    //    public string Parametr {
    //        get { return (string)GetValue(ParametrProperty); }
    //        set { SetValue(ParametrProperty, value); }
    //    }
    //    private static void PrzyciskOtwierania(DependencyObject d, DependencyPropertyChangedEventArgs e) {
    //        var parametr = "Fundusz2.View." + (d as OtworzOkno).Parametr;
    //        // LUB
    //        //var opis = "Fundusz2.View." + (d as OtworzOkno).Przycisk.Tag.ToString();
    //        var okno = (Window)Activator.CreateInstance(Type.GetType(parametr)); //opis lub parametr
    //        void button_Click(object sender, RoutedEventArgs _e) {
    //            okno.ShowDialog();
    //        }
    //        if (e.OldValue != null) ((Button)e.OldValue).Click -= button_Click;
    //        if (e.NewValue != null) ((Button)e.NewValue).Click += button_Click;
    //    }
    //}

    public class OtworzOkno : Behavior<Button> {
        public string Parametr { get; set; }
        protected override void OnAttached() {
            Button przycisk = this.AssociatedObject;
            if (przycisk!=null) przycisk.Click += Przycisk_Click;
        }
        private void Przycisk_Click(object sender, RoutedEventArgs e) {
            try {
                var okno = (Window)Activator.CreateInstance(Type.GetType("Fundusz2.View." + Parametr));
                okno.ShowDialog();
            }
            catch {
                MessageBox.Show("Nie mogęo tworzyć tego okna!");
            }
        }
    }
}
