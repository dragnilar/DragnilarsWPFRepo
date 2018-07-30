using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using SqlJoinyJoins.Classes;
using SqlJoinyJoins.DAL;
using SqlJoinyJoins.DAL.DatabaseBuilders;
using SqlJoinyJoins.Models;

namespace SqlJoinyJoins.Services
{
    public class DatabaseBuilderService
    {

        public void CreateDatabaseIfItDoesNotExist()
        {
            try
            {
                switch (App.Config.DatabaseType)
                {
                    case Globals.GlobalStrings.DataBaseTypes.SqlLite:
                        CreateSqliteDatabaseIfNotExists();
                        break;
                    case Globals.GlobalStrings.DataBaseTypes.MsSqlLocalDb:
                    case Globals.GlobalStrings.DataBaseTypes.MsSql:
                        CreateMsSqlLocalDbDatabaseIfNotExists();
                        break;
                    default:
                        CreateSqliteDatabaseIfNotExists(); //Fall back on Sqlite since its the only one that is truly stand alone
                        break;

                }

            }
            catch (Exception e)
            {
                HandleDatabaseBuildException(e);
            }
            

        }



        private void CreateSqliteDatabaseIfNotExists()
        {
            DatabaseBuilder builder = new SqliteDatabaseBuilder();


            if (!builder.DoesDatabaseExist())
            {
                builder.CreateDatabase();
            }

        }

        private void CreateMsSqlLocalDbDatabaseIfNotExists()
        {
            var dbBuilder = new MsSqlServerDatabaseBuilder();
            if (!dbBuilder.DoesDatabaseExist())
            {
                dbBuilder.CreateAndPopulateTestDatabase();
            }
        }

        private void HandleDatabaseBuildException(Exception e)
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
}
