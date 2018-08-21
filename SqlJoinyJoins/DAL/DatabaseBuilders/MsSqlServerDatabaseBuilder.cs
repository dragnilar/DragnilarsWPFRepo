using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using SqlJoinyJoins.Classes;
using SqlJoinyJoins.DAL;
using SqlJoinyJoins.DAL.DatabaseBuilders;
using SqlJoinyJoins.Globals;

namespace SqlJoinyJoins.Classes
{
    public class MsSqlServerDatabaseBuilder : DatabaseBuilder
    {



        public override void CreateDatabase()
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
            var server = DataAccess.GetLocalMsSqlServer();
            var db = GetTestDatabase(server);
            db.Create();
        }

        private void FillTestDatabase()
        {
            var server = DataAccess.GetLocalMsSqlServer(GlobalStrings.DatabaseName);
            server.ConnectionContext.ExecuteNonQuery(GetDatabaseFillSqlScript());
        }

        private void DropTestDatabaseIfItExists()
        {

            if (DoesDatabaseExist())
            {
                var server = DataAccess.GetLocalMsSqlServer();
                server.KillDatabase(GlobalStrings.DatabaseName);
            }

        }

        public override bool DoesDatabaseExist()
        {
            var server = DataAccess.GetLocalMsSqlServer();

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
