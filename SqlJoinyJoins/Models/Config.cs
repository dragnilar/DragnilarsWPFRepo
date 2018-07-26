using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyrrrz.Settings;

namespace SqlJoinyJoins.Models
{
    public class Config : SettingsManager
    {

        public string DatabaseType = Globals.GlobalStrings.DataBaseTypes.SqlLite;
        public string MsSqlServer = "";
        public string MsSqlLocalDbServer = @"(LocalDB)\MSSQLLocalDB";

        public Config()
        {
            Configuration.StorageSpace = StorageSpace.Instance;
            Configuration.FileName = "SettingsFile.json";
            Configuration.SubDirectoryPath = "Settings";
        }
    }
}
