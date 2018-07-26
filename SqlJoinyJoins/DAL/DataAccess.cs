using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace SqlJoinyJoins.Classes
{
    public static class DataAccess
    {


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
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                IntegratedSecurity = true,
                ConnectTimeout = 30
            };
            return sqlConnectionStringBuilder;
        }
    }
}
