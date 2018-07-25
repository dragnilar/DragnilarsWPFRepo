using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using SqlJoinyJoins.Classes;

namespace SqlJoinyJoins.Classes
{
    public class DatabaseBuilder
    {



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
            var server = DataAccessLayer.GetLocalDbServer();
            var db = GetTestDatabase(server);
            db.Create();
        }

        private void FillTestDatabase()
        {
            var server = DataAccessLayer.GetLocalDbServer(GlobalStrings.DatabaseName);
            server.ConnectionContext.ExecuteNonQuery(GetDatabaseFillSqlScript());
        }

        private void DropTestDatabaseIfItExists()
        {

            if (DoesDatabaseExist())
            {
                var server = DataAccessLayer.GetLocalDbServer();
                server.KillDatabase(GlobalStrings.DatabaseName);
            }

        }

        public bool DoesDatabaseExist()
        {
            var server = DataAccessLayer.GetLocalDbServer();

            return server.Databases.Contains(GlobalStrings.DatabaseName);
        }

        private Database GetTestDatabase(Server server)
        {
            var testDb = new Database(server, GlobalStrings.DatabaseName);
            return testDb;
        }


        private string GetDatabaseFillSqlScript()
        {
            return Properties.Resources.JoinyJoinsDatabaseFill;
        }
    }
}
