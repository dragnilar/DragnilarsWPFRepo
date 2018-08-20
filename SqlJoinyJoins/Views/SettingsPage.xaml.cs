using System.Windows.Controls;
using Ninject;
using SqlJoinyJoins.Services;
using SqlJoinyJoins.ViewModels;

namespace SqlJoinyJoins.Views
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
            DataContext = new SettingsPageViewModel(App.Ninject.Get<MessageBoxService>());
        }
    }
}
