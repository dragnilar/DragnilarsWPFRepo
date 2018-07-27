using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using SqlJoinyJoins.DAL;
using SqlJoinyJoins.Globals;

namespace SqlJoinyJoins.Classes
{
    public static class DataAccess
    {
        public static SQLiteConnection GetDefaultSqliteConnection()
        {
            var connection = new SQLiteConnection(GetSqlLiteConnectionString());

            return connection;
        }
        private static string GetSqlLiteConnectionString()
        {
            var builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = ".\\db\\sqlJoinyJoinsdb\\SqlJoinyJoinsDb.sqlite";
            builder.ForeignKeys = true;

            return builder.ToString();
        }

        public static Server GetLocalMsSqlServer(string databaseName = null)
        {
            var server = new Server();
            var sqlConnectionStringBuilder = GetConnectionStringBuilderForServer();
            if (!string.IsNullOrWhiteSpace(databaseName))
            {
                sqlConnectionStringBuilder.InitialCatalog = databaseName;
            }
            server.ConnectionContext.ConnectionString = sqlConnectionStringBuilder.ConnectionString;
            return server;
        }

        private static SqlConnectionStringBuilder GetConnectionStringBuilderForServer()
        {
            var server = App.Config.DatabaseType == GlobalStrings.DataBaseTypes.MsSqlLocalDb ? App.Config.MsSqlLocalDbServer : App.Config.MsSqlServer;
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                IntegratedSecurity = true,
                ConnectTimeout = 30
            };
            return sqlConnectionStringBuilder;
        }


        public static DataView GetCrossJoinData()
        {
            var query = Properties.Resources.CrossJoinQuery;
            return App.Config.DatabaseType == GlobalStrings.DataBaseTypes.SqlLite
                ? GetTableUsingEntityFramework(query)
                : GetTableUsingSMO(query);
        }

        public static DataView GetInnerJoinData()
        {
            var query = Properties.Resources.FullInnerJoinQuery;
            return App.Config.DatabaseType == GlobalStrings.DataBaseTypes.SqlLite
                ? GetTableUsingEntityFramework(query)
                : GetTableUsingSMO(query);
        }

        public static DataView GetOuterJoinData()
        {
            return App.Config.DatabaseType == GlobalStrings.DataBaseTypes.SqlLite
                ? GetTableUsingEntityFramework(Properties.Resources.FullOuterJoinQuerySqlite)
                : GetTableUsingSMO(Properties.Resources.FullOuterJoinQuery);
        }

        public static DataView GetLeftJoinData()
        {
            var query = Properties.Resources.LeftJoinQuery;
            return App.Config.DatabaseType == GlobalStrings.DataBaseTypes.SqlLite
                ? GetTableUsingEntityFramework(query)
                : GetTableUsingSMO(query);
        }

        public static DataView GetRightJoinData()
        {
            return App.Config.DatabaseType == GlobalStrings.DataBaseTypes.SqlLite
                ? GetTableUsingEntityFramework(Properties.Resources.RightJoinQuerySqlite)
                : GetTableUsingSMO(Properties.Resources.RightJoinQuery);
        }

        public static DataView GetTableOneSource()
        {
            const string selectStatement = "select * from WeaponAttributes";
            return App.Config.DatabaseType == GlobalStrings.DataBaseTypes.SqlLite ? GetTableUsingEntityFramework(selectStatement) : GetTableUsingSMO(selectStatement);
        }


        public static DataView GetTableTwoSource()
        {
            const string selectStatement = "select * from Weapons";
            return App.Config.DatabaseType == GlobalStrings.DataBaseTypes.SqlLite ? GetTableUsingEntityFramework(selectStatement) : GetTableUsingSMO(selectStatement);
        }

        public static (DataView result, Exception error) GetTableForCustomQuery(string sqlStatement)
        {
            DataView result;

            try
            {
                result = App.Config.DatabaseType == GlobalStrings.DataBaseTypes.SqlLite ?
                    GetTableUsingEntityFramework(sqlStatement) : GetTableUsingSMO(sqlStatement);
            }
            catch (Exception e)
            {
                return (null, e);

            }

            return (result, null);
        }

        private static DataView GetTableUsingSMO(string sqlStatement)
        {
            var server = GetLocalMsSqlServer(GlobalStrings.DatabaseName);

            var set = server.ConnectionContext.ExecuteWithResults(sqlStatement);

            return set.Tables.Count == 1 ? set.Tables[0].DefaultView : null;
        }

        private static DataView GetTableUsingEntityFramework(string sqlStatement)
        {
            var dataTable = new DataTable();
            using (var context = new SqlLiteDbContext(GetDefaultSqliteConnection(), false))
            {
                var command = context.Database.Connection.CreateCommand();
                command.CommandText = sqlStatement;
                command.Connection.Open();
                dataTable.Load(command.ExecuteReader());
                command.Connection.Close();
                return dataTable.DefaultView;
            }
        }


    }
}
