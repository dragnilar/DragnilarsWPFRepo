using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlJoinyJoins.Models;
using SQLite.CodeFirst;

namespace SqlJoinyJoins.DAL
{
    public class SqlLiteDbContextInitializer : SqliteDropCreateDatabaseAlways<SqlLiteDbContext>
    {
        public SqlLiteDbContextInitializer(DbModelBuilder modelBuilder) : base(modelBuilder) { }

        protected override void Seed(SqlLiteDbContext context)
        {
            //var weapons = GetWeaponSeed();
            //context.Set<Weapon>().AddRange(weapons);

            //var weaponAttributes = GetWeaponAttributeSeed();

            //context.Set<WeaponAttribute>().AddRange(weaponAttributes);
        }
    }
}
