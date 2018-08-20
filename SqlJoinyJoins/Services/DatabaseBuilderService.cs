using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using Ninject.Modules;
using SqlJoinyJoins.Classes;
using SqlJoinyJoins.DAL;
using SqlJoinyJoins.DAL.DatabaseBuilders;
using SqlJoinyJoins.Models;

namespace SqlJoinyJoins.Services
{
    public interface IDatabaseBuilderService
    {
        bool DoesDatabaseExist();
        void CreateDatabaseIfItDoesNotExist();
    }

    public class DatabaseBuilderService : NinjectModule, IDatabaseBuilderService
    {
        private readonly DatabaseBuilder _builder;

        public DatabaseBuilderService()
        {
            switch (App.Config.DatabaseType)
            {
                case Globals.GlobalStrings.DataBaseTypes.SqlLite:
                    _builder = new SqliteDatabaseBuilder();
                    break;
                case Globals.GlobalStrings.DataBaseTypes.MsSqlLocalDb:
                case Globals.GlobalStrings.DataBaseTypes.MsSql:
                    _builder = new MsSqlServerDatabaseBuilder();
                    break;
                default:
                    _builder = new SqliteDatabaseBuilder(); //Fall back on Sqlite since its the only one that is truly stand alone
                    break;
            }
        }

        public bool DoesDatabaseExist()
        {

            try
            {
                return _builder.DoesDatabaseExist();
            }
            catch (Exception e)
            {
                HandleDatabaseBuildException(e);
                return false;
            }
        }


        public void CreateDatabaseIfItDoesNotExist()
        {
            
            try
            {
                if (!_builder.DoesDatabaseExist())
                {
                    _builder.CreateDatabase();
                }

            }
            catch (Exception e)
            {
                HandleDatabaseBuildException(e);
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


        public override void Load()
        {
            Bind<IDatabaseBuilderService>().ToSelf().InSingletonScope();
        }
    }
}
