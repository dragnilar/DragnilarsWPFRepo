using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlJoinyJoins.Models;
using SQLite.CodeFirst;

namespace SqlJoinyJoins.DAL
{
    public class SqlLiteDbContext : DbContext
    {
        public SqlLiteDbContext(SQLiteConnection connection, bool owned) : base(connection, owned) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInit = new SqliteCreateDatabaseIfNotExists<SqlLiteDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInit);
        }


        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<WeaponAttribute> WeaponAttributes { get; set; }


        
    }
}
