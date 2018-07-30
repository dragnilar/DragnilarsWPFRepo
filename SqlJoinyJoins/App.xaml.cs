using System;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using SqlJoinyJoins.Classes;
using SqlJoinyJoins.DAL;
using SqlJoinyJoins.Factories;
using SqlJoinyJoins.Models;
using SqlJoinyJoins.Services;

namespace SqlJoinyJoins
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly Config Config = new Config();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetupExceptionHandling();
            CheckSettings();
            RunLoadingRoutine();
        }

        private static void RunLoadingRoutine()
        {
            DXSplashScreen.Show<Splashy>();
            DXSplashScreen.SetState("Loading...");
            var service = new DatabaseBuilderService();
            service.CreateDatabaseIfItDoesNotExist();
        }

        private void SetupExceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                LogUnhandledException((Exception)e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

            DispatcherUnhandledException += (s, e) =>
                LogUnhandledException(e.Exception, "Application.Current.DispatcherUnhandledException");

            TaskScheduler.UnobservedTaskException += (s, e) =>
                LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");
        }

        private void LogUnhandledException(Exception eExceptionObject, string source)
        {
            //TODO CHANGE ME
            if (DXSplashScreen.IsActive)
            {
                DXSplashScreen.Close();
            }

            MessageBox.Show(eExceptionObject.ToString(), "Unhandled Exception", MessageBoxButton.OK,
                MessageBoxImage.Error);

            Current.Shutdown();
        }

        private void CheckSettings()
        {
            if (File.Exists(Config.FullFilePath))
            {
                Config.Load();
            }
        }
    }
}
