using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlJoinyJoins.Classes;
using SqlJoinyJoins.Factories;
using SqlJoinyJoins.Models;

namespace SqlJoinyJoins.DAL
{
    public class SqliteDatabaseBuilder
    {
        public bool DoesDatabaseExist()
        {
            var result = true;
            var context = new SqlLiteDbContext(DataAccess.GetDefaultSqliteConnection(), false);

            if (!context.Set<Weapon>().Any())
            {
                result = false;
            }

            if (!context.Set<WeaponAttribute>().Any())
            {
                result = false;
            }

            context.Dispose();

            return result;
        }
        public void CreateSqlLiteDatabase()
        {
            var context = new SqlLiteDbContext(DataAccess.GetDefaultSqliteConnection(), false);

            if (!context.Set<Weapon>().Any())
            {
                context.Set<Weapon>().AddRange(new DefaultDataFactory().GetWeaponSeed());
                context.SaveChanges();
            }

            if (!context.Set<WeaponAttribute>().Any())
            {
                context.Set<WeaponAttribute>().AddRange(new DefaultDataFactory().GetWeaponAttributeSeed());
                context.SaveChanges();
            }
            
            context.Dispose();
            
        }
    }
}
