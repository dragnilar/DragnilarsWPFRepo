using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SqlJoinyJoins.Classes;
using SqlJoinyJoins.Globals;
using SqlJoinyJoins.Models;

namespace SqlJoinyJoins.Views
{
    /// <summary>
    /// Interaction logic for RightJoinView.xaml
    /// </summary>
    public partial class RightJoinView : UserControl
    {
        public ExampleData ViewData = new ExampleData();
        public RightJoinView()
        {
            InitializeComponent();
            SetUpControls();
        }


        private void SetUpControls()
        {
            ViewData.Explanation = Properties.Resources.RightJoinExplanation;
            ViewData.GridSource = GetDataSourceData();
            ViewData.TableOneSource = GetTableOneSource();
            ViewData.TableTwoSource = GetTableTwoSource();
            ViewData.QueryUsed = Properties.Resources.RightJoinQuery;
            DataContext = ViewData;
        }




        private DataView GetDataSourceData()
        {
            var selectStatement = "select AttributeWeaponType, AttributeName, WeaponName, WeaponType\r\nFrom WeaponAttributes\r\n\tRight Join Weapons\r\n\ton WeaponAttributes.WeaponId = Weapons.WeaponId\r\nOrder By AttributeWeaponType";

            var server = DataAccess.GetLocalMsSqlServer(GlobalStrings.DatabaseName);

            var set = server.ConnectionContext.ExecuteWithResults(selectStatement);

            return set.Tables.Count == 1 ? set.Tables[0].DefaultView : null;
        }

        private DataView GetTableOneSource()
        {
            var selectStatement = "select * from WeaponAttributes";
            var server = DataAccess.GetLocalMsSqlServer(GlobalStrings.DatabaseName);

            var set = server.ConnectionContext.ExecuteWithResults(selectStatement);

            return set.Tables.Count == 1 ? set.Tables[0].DefaultView : null;
        }

        private DataView GetTableTwoSource()
        {
            var selectStatement = "select * from Weapons";

            var server = DataAccess.GetLocalMsSqlServer(GlobalStrings.DatabaseName);

            var set = server.ConnectionContext.ExecuteWithResults(selectStatement);

            return set.Tables.Count == 1 ? set.Tables[0].DefaultView : null;
        }
    }
}
