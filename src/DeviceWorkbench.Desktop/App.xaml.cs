using System.Windows;
using DeviceWorkbench.Desktop.ViewModels;
using DeviceWorkbench.Desktop.Views;

namespace DeviceWorkbench.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Compose the initial screen here; device services can be injected later.
            MainWindow = new MainWindow(new MainViewModel());
            MainWindow.Show();
        }
    }
}
