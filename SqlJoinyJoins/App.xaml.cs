using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Xpf.Core;
using SqlJoinyJoins.Models;
using SqlJoinyJoins.Services;
using SqlJoinyJoins.Views;

namespace SqlJoinyJoins
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly Config Config = new Config();
        public static DatabaseBuilderService DBBuilder = new DatabaseBuilderService();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetupExceptionHandling();
            CheckSettings();
            CheckDatabase();
        }

        private void SetupExceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                LogUnhandledException((Exception) e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

            DispatcherUnhandledException += (s, e) =>
                LogUnhandledException(e.Exception, "Application.Current.DispatcherUnhandledException");

            TaskScheduler.UnobservedTaskException += (s, e) =>
                LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");
        }

        private void LogUnhandledException(Exception eExceptionObject, string source)
        {
            //TODO CHANGE ME
            if (DXSplashScreen.IsActive) DXSplashScreen.Close();

            MessageBox.Show(eExceptionObject.ToString(), "Unhandled Exception", MessageBoxButton.OK,
                MessageBoxImage.Error);

            Current.Shutdown();
        }

        private void CheckSettings()
        {
            if (File.Exists(Config.FullFilePath)) Config.Load();
        }

        private void CheckDatabase()
        {
            DXSplashScreen.Show<Splashy>();
            DXSplashScreen.SetState("Loading...");
            Thread.Sleep(1000);
            DXSplashScreen.SetState("Checking For Database....");
            if (!DBBuilder.DoesDatabaseExist())
            {
                DXSplashScreen.SetState("Creating Test Database....");
                DBBuilder.CreateDatabaseIfItDoesNotExist();
                DXSplashScreen.SetState("Finished creating database....");
            }
            DXSplashScreen.Close();
        }


    }
}