using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Fundusz2.Zachowania {

    #region ZAMKNIJ OKNO
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
                if (okno is MainWindow) Application.Current.Shutdown(); //
            }
            if (e.OldValue != null) ((Button)e.OldValue).Click -= button_Click;
            if (e.NewValue != null) ((Button)e.NewValue).Click += button_Click;
        }
    }
    #endregion

    #region OTWÓRZ OKNO
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
                MessageBox.Show("Nie mogę otworzyć tego okna!");
            }
        }
    }
    #endregion
}
