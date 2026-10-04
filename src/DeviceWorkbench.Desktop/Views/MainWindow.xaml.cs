using System;
using System.Windows;
using DeviceWorkbench.Desktop.ViewModels;

namespace DeviceWorkbench.Desktop.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
