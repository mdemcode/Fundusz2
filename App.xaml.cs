using System.Threading.Tasks;
using System.Windows;

namespace Fundusz2{
    public partial class App : Application {

        protected override void OnStartup(StartupEventArgs e) { //Dziwna konstrukcja, nie wiem czy poprawna, ale działa tak jak chcę :)
            base.OnStartup(e);
            //initialize the splash screen and set it as the application main window
            var oknoGlowne = this.MainWindow;
            var splashScreen = new StartLogo();
            this.MainWindow = splashScreen;
            splashScreen.Show();
            //in order to ensure the UI stays responsive, we need to
            //do the work on a different thread
            Task.Factory.StartNew(() => {
                this.Dispatcher.Invoke(() => {
                    splashScreen.Close();
                    this.MainWindow = oknoGlowne;
                });
            });
        }
    }
}
