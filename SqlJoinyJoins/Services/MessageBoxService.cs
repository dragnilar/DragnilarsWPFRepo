using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using DevExpress.Xpf.WindowsUI;

namespace SqlJoinyJoins.Services
{
    public interface IWindowsUIMessageBoxService
    {
        MessageBoxResult ShowMessage(string text, string caption, MessageBoxButton button, MessageBoxImage icon);
    }
    class MessageBoxService : IWindowsUIMessageBoxService
    {
        public MessageBoxResult ShowMessage(string text, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return WinUIMessageBox.Show(text, caption, button, icon);
        }
    }


}
