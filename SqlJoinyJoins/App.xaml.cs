using System;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Core;
using SqlJoinyJoins.Classes;
using SqlJoinyJoins.DAL;
using SqlJoinyJoins.Factories;
using SqlJoinyJoins.Models;

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
            CheckSettings();
            DXSplashScreen.Show<Splashy>();

            DXSplashScreen.SetState("Loading...");
            CreateDatabaseIfItExists();

            
        }

        private void CheckSettings()
        {
            if (File.Exists(Config.FullFilePath))
            {
                Config.Load();
            }
        }

        

        private void CreateDatabaseIfItExists()
        {
            try
            {
                if (Config.DatabaseType == Globals.GlobalStrings.DataBaseTypes.MsSqlLocalDb || Config.DatabaseType == Globals.GlobalStrings.DataBaseTypes.MsSql)
                {
                    CreateMsSqlLocalDbDatabaseIfNotExists();
                }
                else if (Config.DatabaseType == Globals.GlobalStrings.DataBaseTypes.SqlLite)
                {
                    CreateSqliteDatabaseIfNotExists();
                }
            }
            catch (Exception e)
            {
                if (DXSplashScreen.IsActive)
                {
                    DXSplashScreen.Close();
                }

                DXMessageBox.Show(
                    "Error occurred creating the database. \n If you are trying to use Microsoft Sql Server, \n" +
                    "please verify that it is installed (Express/Full or LocalDB).\n Additional Error Information:\n\n" +
                    e,
                    "Error Creating Database", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }

        }

        private void CreateSqliteDatabaseIfNotExists()
        {

            var dbBuilder = new SqliteDatabaseBuilder();
            if (!dbBuilder.DoesDatabaseExist())
            {
                DXSplashScreen.SetState("Creating Database, Please Wait...");
                dbBuilder.CreateSqlLiteDatabase();
                DXSplashScreen.SetState("Test Database Created, Loading...");
            }
          
        }

        private static void CreateMsSqlLocalDbDatabaseIfNotExists()
        {
            var dbBuilder = new MsSqlServerDatabaseBuilder();
            if (!dbBuilder.DoesDatabaseExist())
            {
                DXSplashScreen.SetState("Creating Database, Please Wait...");
                dbBuilder.CreateAndPopulateTestDatabase();
                DXSplashScreen.SetState("Test Database Created, Loading...");
            }
        }
    }
}
