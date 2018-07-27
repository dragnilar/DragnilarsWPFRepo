using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using SqlJoinyJoins.ViewModels;

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

        public SettingsPageViewModel vm;

        private void SetUpControls()
        {
            vm = new SettingsPageViewModel();
            DataContext = vm;
        }
    }
}
