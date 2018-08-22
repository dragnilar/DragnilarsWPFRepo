using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Xpf.Core;
using Ninject;
using Ninject.Modules;
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
        public static IKernel Ninject;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
           // SetupExceptionHandling();
            Ninject = SetUpNinjectKernel();
            CheckSettings();
            CheckDatabase(Ninject.Get<DatabaseBuilderService>());
            Current.MainWindow = Ninject.Get<MainWindow>();
            Current.MainWindow.Show();
        }


        private StandardKernel SetUpNinjectKernel()
        {
            var modules = new INinjectModule[]
            {
                new MessageBoxService(),
                new DatabaseBuilderService()
            };

            return new StandardKernel(modules);
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

        private void CheckDatabase(IDatabaseBuilderService service)
        {
            DXSplashScreen.Show<Splashy>();
            DXSplashScreen.SetState("Loading...");
            Thread.Sleep(1000);
            DXSplashScreen.SetState("Checking For Database....");
            if (!service.DoesDatabaseExist())
            {
                DXSplashScreen.SetState("Creating Test Database....");
                service.CreateDatabaseIfItDoesNotExist();
                DXSplashScreen.SetState("Finished creating database....");
            }
            DXSplashScreen.Close();
        }


    }
}