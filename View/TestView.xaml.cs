using System.Windows;

namespace Fundusz2.View
{
    public partial class TestView : Window {
        public TestView() {
            InitializeComponent();
        }

        private void ZamknijButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
