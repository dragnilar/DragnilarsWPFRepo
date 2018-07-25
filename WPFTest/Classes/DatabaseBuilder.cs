using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace SqlJoinyJoins.Classes
{
    public class DatabaseBuilder
    {

        private string DatabaseName = "SQLJoinyJoinsDb";

        public void CreateAndPopulateTestDatabase()
        {
            try
            {
                DropTestDatabaseIfItExists();
                CreateTestDatabase();
                FillTestDatabase();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private void CreateTestDatabase()
        {
            var server = GetLocalDBServer();
            var db = GetTestDatabase(server);
            db.Create();
        }

        private void FillTestDatabase()
        {
            var server = GetLocalDBServerWithDatabase();
            server.ConnectionContext.ExecuteNonQuery(GetDatabaseFillSqlScript());
        }

        private void DropTestDatabaseIfItExists()
        {

            if (DoesDatabaseExist())
            {
                var server = GetLocalDBServer();
                server.KillDatabase(DatabaseName);
            }

        }

        public bool DoesDatabaseExist()
        {
            var server = GetLocalDBServer();

            return server.Databases.Contains(DatabaseName);
        }

        private Server GetLocalDBServer()
        {
            var server = new Server();
            var sqlConnectionStringBuilder = GetConnectionStringBuilderForServer();
            server.ConnectionContext.ConnectionString = sqlConnectionStringBuilder.ConnectionString;
            return server;
        }

        private Server GetLocalDBServerWithDatabase()
        {
            var server = new Server();
            var sqlConnectionStringBuilder = GetConnectionStringBuilderForServer();
            sqlConnectionStringBuilder.InitialCatalog = DatabaseName;
            server.ConnectionContext.ConnectionString = sqlConnectionStringBuilder.ConnectionString;
            return server;
        }

        private SqlConnectionStringBuilder GetConnectionStringBuilderForServer()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                IntegratedSecurity = true,
                ConnectTimeout = 30
            };
            return sqlConnectionStringBuilder;
        }



        private Database GetTestDatabase(Server server)
        {
            var testDb = new Database(server, DatabaseName);
            return testDb;
        }


        private string GetDatabaseFillSqlScript()
        {
            return Properties.Resources.JoinyJoinsDatabaseFill;
        }
    }
}
