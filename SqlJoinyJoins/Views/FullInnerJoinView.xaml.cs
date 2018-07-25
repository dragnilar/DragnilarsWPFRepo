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
using DevExpress.Xpf.Core.HandleDecorator;
using SqlJoinyJoins.Classes;

namespace SqlJoinyJoins.Views
{
    /// <summary>
    /// Interaction logic for FullInnerJoinView.xaml
    /// </summary>
    public partial class FullInnerJoinView : UserControl
    {
        public ExampleData ViewData = new ExampleData();

        public FullInnerJoinView()
        {
            InitializeComponent();
            SetUpControls();
        }

        private void SetUpControls()
        {
            ViewData.Explanation = Properties.Resources.FullInnerJoinExplanation;
            ViewData.GridSource = GetDataSourceData();
            ViewData.TableOneSource = GetTableOneSource();
            ViewData.TableTwoSource = GetTableTwoSource();
            ViewData.QueryUsed = Properties.Resources.FullInnerJoinQuery;
            DataContext = ViewData;
        }




        private DataView GetDataSourceData()
        {
            var selectStatement = "select AttributeWeaponType, AttributeName, WeaponName, WeaponType\r\nFrom WeaponAttributes\r\n\t Join Weapons " +
                                  "on WeaponAttributes.WeaponId = Weapons.WeaponId\r\nOrder By AttributeWeaponType   ";

            var server = DataAccessLayer.GetLocalDbServer(GlobalStrings.DatabaseName);

            var set = server.ConnectionContext.ExecuteWithResults(selectStatement);

            return set.Tables.Count == 1 ? set.Tables[0].DefaultView : null;
        }

        private DataView GetTableOneSource()
        {
            var selectStatement = "select * from WeaponAttributes";
            var server = DataAccessLayer.GetLocalDbServer(GlobalStrings.DatabaseName);

            var set = server.ConnectionContext.ExecuteWithResults(selectStatement);

            return set.Tables.Count == 1 ? set.Tables[0].DefaultView : null;
        }

        private DataView GetTableTwoSource()
        {
            var selectStatement = "select * from Weapons";

            var server = DataAccessLayer.GetLocalDbServer(GlobalStrings.DatabaseName);

            var set = server.ConnectionContext.ExecuteWithResults(selectStatement);

            return set.Tables.Count == 1 ? set.Tables[0].DefaultView : null;
        }
    }
}
