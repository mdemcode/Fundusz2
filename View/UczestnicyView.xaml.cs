using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fundusz2.View
{
    /// <summary>
    /// Interaction logic for UczestnicyView.xaml
    /// </summary>
    public partial class UczestnicyView : Window
    {
        public UczestnicyView()
        {
            InitializeComponent();
        }

        //TODO DO USUNIECIA!
        private void ZamknijButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
