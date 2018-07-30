using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlJoinyJoins.DAL.DatabaseBuilders
{
    public abstract class DatabaseBuilder
    {

        public abstract void CreateDatabase();

        public abstract bool DoesDatabaseExist();
    } 
}
