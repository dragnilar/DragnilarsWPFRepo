using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlJoinyJoins.DAL;
using SqlJoinyJoins.Globals;
using SqlJoinyJoins.Models;

namespace SqlJoinyJoins.Services
{
    public class JoinModelService
    {

        public ExampleData GetInnerJoinViewModel()
        {
            var data = new ExampleData
            {
                Explanation = Properties.Resources.FullInnerJoinExplanation,
                GridSource = DataAccess.GetInnerJoinData(),
                TableOneSource = DataAccess.GetTableOneSource(),
                TableTwoSource = DataAccess.GetTableTwoSource(),
                QueryUsed = Properties.Resources.FullInnerJoinQuery,
                Title = "Inner Join"
            };

            return data;

        }

        public ExampleData GetOuterJoinViewModel()
        {
            var data = new ExampleData
            {
                Explanation = Properties.Resources.FullOuterJoinExplanation,
                GridSource = DataAccess.GetOuterJoinData(),
                TableOneSource = DataAccess.GetTableOneSource(),
                TableTwoSource = DataAccess.GetTableTwoSource(),
                QueryUsed = App.Config.DatabaseType == GlobalStrings.DataBaseTypes.SqlLite
                    ? Properties.Resources.FullOuterJoinQuerySqlite : Properties.Resources.FullOuterJoinQuery,
                Title = "Outer Join"
            };

            return data;

        }

        public ExampleData GetLeftJoinViewModel()
        {
            var data = new ExampleData
            {
                Explanation = Properties.Resources.LeftJoinExplanation,
                GridSource = DataAccess.GetLeftJoinData(),
                TableOneSource = DataAccess.GetTableOneSource(),
                TableTwoSource = DataAccess.GetTableTwoSource(),
                QueryUsed = Properties.Resources.LeftJoinQuery,
                Title = "Left Join"
            };

            return data;

        }

        public ExampleData GetRightJoinViewModel()
        {
            var data = new ExampleData
            {
                Explanation = Properties.Resources.RightJoinExplanation,
                GridSource = DataAccess.GetRightJoinData(),
                TableOneSource = DataAccess.GetTableOneSource(),
                TableTwoSource = DataAccess.GetTableTwoSource(),
                QueryUsed = App.Config.DatabaseType == GlobalStrings.DataBaseTypes.SqlLite
                    ? Properties.Resources.RightJoinQuerySqlite : Properties.Resources.RightJoinQuery,
                Title = "Right Join"
            };

            return data;

        }

        public ExampleData GetCrossJoinViewModel()
        {
            var data = new ExampleData
            {
                Explanation = Properties.Resources.CrossJoinExplanation,
                GridSource = DataAccess.GetCrossJoinData(),
                TableOneSource = DataAccess.GetTableOneSource(),
                TableTwoSource = DataAccess.GetTableTwoSource(),
                QueryUsed = Properties.Resources.CrossJoinQuery,
                Title = "Cross Join"
            };

            return data;
        }

    }
}
