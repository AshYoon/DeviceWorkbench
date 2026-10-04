using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DeviceWorkbench.Desktop.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public string Title => "DeviceWorkbench";

        public string ConnectionStatus => "미연결";

        [ObservableProperty]
        private string _workName = string.Empty;

        public ObservableCollection<string> ActivityLog { get; } =
            new ObservableCollection<string>
            {
                "프로그램을 시작했습니다."
            };

        [RelayCommand]
        private void ClearLog()
        {
            ActivityLog.Clear();
        }
    }
}
