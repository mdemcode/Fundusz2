using System;
using System.Windows;

namespace Fundusz2.View
{
    public partial class TestView : Window {
        public TestView() {
            InitializeComponent();
        }

        private void TestButton1_Click(object sender, RoutedEventArgs e)
        {
            //todo do usuniecia
            string nazwa = "Fundusz2.View.UczestnicyView"; //MUSI BYĆ PEŁNA ŚCIEŻKA!
            var strona = (Window)Activator.CreateInstance(Type.GetType(nazwa));
            strona.ShowDialog();
        }
    }
}
