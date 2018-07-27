using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Core;

namespace SqlJoinyJoins
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
            SetUpControls();
        }

        private void SetUpControls()
        {
            if (App.Config.DatabaseType == Globals.GlobalStrings.DataBaseTypes.SqlLite)
            {
                ListBoxEditServerType.SelectedItem = ListBoxEditItemSqlite;
            }
            else if (App.Config.DatabaseType == Globals.GlobalStrings.DataBaseTypes.MsSqlLocalDb)
            {
                ListBoxEditServerType.SelectedItem = ListBoxEditItemMsSqlLocalDb;
            }

            else if (App.Config.DatabaseType == Globals.GlobalStrings.DataBaseTypes.MsSql)
            {
                ListBoxEditServerType.SelectedItem = ListBoxEditItemMsSql;
            }

            else
            {
                ListBoxEditServerType.SelectedItem = ListBoxEditItemSqlite;
            }
        }

        private void SimpleButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (Equals(ListBoxEditServerType.SelectedItem, ListBoxEditItemSqlite))
            {
                App.Config.DatabaseType = Globals.GlobalStrings.DataBaseTypes.SqlLite;

            }

            else if (Equals(ListBoxEditServerType.SelectedItem, ListBoxEditItemMsSqlLocalDb))
            {
                App.Config.DatabaseType = Globals.GlobalStrings.DataBaseTypes.MsSqlLocalDb;
            }

            else if (Equals(ListBoxEditServerType.SelectedItem, ListBoxEditItemMsSql))
            {
                App.Config.DatabaseType = Globals.GlobalStrings.DataBaseTypes.MsSql;
            }

            else
            {
                App.Config.DatabaseType = Globals.GlobalStrings.DataBaseTypes.SqlLite;
            }

            App.Config.Save();
            DXMessageBox.Show("SettingsPage Saved!", "SettingsPage Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
