using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Xpf.WindowsUI;
using Ninject;
using SqlJoinyJoins.Globals;
using SqlJoinyJoins.Models;
using SqlJoinyJoins.Services;

namespace SqlJoinyJoins.ViewModels
{
    public class SettingsPageViewModel
    {
        private readonly bool _canExecute = true;

        private ICommand _saveSettingsCommand;

        protected IWindowsUIMessageBoxService WindowsUiMessageBoxService; 

        public ObservableCollection<ServerTypeItem> ServerTypeItems { get; set; }

        public object SelectedServerType { get; set; }

        public ICommand SaveSettingsCommand => _saveSettingsCommand ?? (_saveSettingsCommand = new SettingsPageCommand(SaveSettings, _canExecute));


        public SettingsPageViewModel(IWindowsUIMessageBoxService messageBoxService)
        {
            WindowsUiMessageBoxService = messageBoxService;
            CreateList();
            SelectedServerType = ServerTypeItems.FirstOrDefault(r => r.ServerType == App.Config.DatabaseType);
        }
        private void CreateList()
        {
            ServerTypeItems = new ObservableCollection<ServerTypeItem>
            {
                new ServerTypeItem("SQLite", GlobalStrings.DataBaseTypes.SqlLite),
                new ServerTypeItem("MS SQL Server Local DB", GlobalStrings.DataBaseTypes.MsSqlLocalDb),
                new ServerTypeItem("MS SQL Server", GlobalStrings.DataBaseTypes.MsSql)
            };
        }

        public void SaveSettings()
        {
            App.Config.DatabaseType = ((ServerTypeItem) SelectedServerType).ServerType;
            App.Config.Save();
            WindowsUiMessageBoxService.ShowMessage("Settings have been saved. If you changed your server type, \n" +
                                 "you should restart the application.", "Settings Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        }



        public class SettingsPageCommand : ICommand
        {
            private readonly Action _action;
            private readonly bool _canExecute;

            public SettingsPageCommand(Action action, bool canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public void Execute(object parameter)
            {
                _action();
            }

            public event EventHandler CanExecuteChanged;
        }
    }
}