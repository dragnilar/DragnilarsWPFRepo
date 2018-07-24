using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace WPFTest.Classes
{
    public class DatabaseBuilder
    {

        public string DatabaseName = "SQLJoinyJoinsDb";

        public void CreateAndPopulateTestDatabase()
        {
            try
            {
                var server = GetLocalDBServer();
                DropTestDatabaseIfItExists(server);

                var db = GetTestDatabase(server);
                db.Create();

                server = null;

                server = GetLocalDBServer();


                server.ConnectionContext.ExecuteNonQuery(GetDatabaseFillSqlScript());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DropTestDatabaseIfItExists(Server server = null)
        {
            if (server == null)
            {
                server = GetLocalDBServer();
            }


            if (server.Databases.Contains(DatabaseName))
            {
                server.KillDatabase(DatabaseName);
            }

        }

        public Server GetLocalDBServer()
        {
            var server = new Server();

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                IntegratedSecurity = true,
                ConnectTimeout = 30
            };


            server.ConnectionContext.ConnectionString = sqlConnectionStringBuilder.ConnectionString;

            return server;
        }

        public Database GetTestDatabase(Server server)
        {
            var testDb = new Database(server, DatabaseName);
            return testDb;
        }


        public string GetDatabaseFillSqlScript()
        {
            return Properties.Resources.JoinyJoinsDatabaseFill;
            ;
        }
    }
}
