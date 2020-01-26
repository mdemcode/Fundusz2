using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fundusz2.ViewModel {
    public static class Tools {

        public static void ZamknijOkno(string tytulOkna) {
            foreach (Window window in Application.Current.Windows) {
                if (window.Title == tytulOkna) window.Close();
            }
        }
    }
}
