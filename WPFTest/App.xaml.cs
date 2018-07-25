using System.Windows;
using DevExpress.Xpf.Core;
using SqlJoinyJoins.Classes;

namespace SqlJoinyJoins
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DXSplashScreen.Show<Splashy>();

            DXSplashScreen.SetState("Loading...");
            CreateDatabaseIfItExists();

            
        }

        private void CreateDatabaseIfItExists()
        {
            var dbBuilder = new DatabaseBuilder();
            if (!dbBuilder.DoesDatabaseExist())
            {
                DXSplashScreen.SetState("Creating Database, Please Wait...");
                dbBuilder.CreateAndPopulateTestDatabase();
                DXSplashScreen.SetState("Test Database Created, Loading...");
            }
        }
    }
}
