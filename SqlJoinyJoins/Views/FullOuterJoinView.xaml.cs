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
    /// Interaction logic for FullOuterJoinView.xaml
    /// </summary>
    public partial class FullOuterJoinView : UserControl
    {
        public ExampleData ViewData = new ExampleData();
        public FullOuterJoinView()
        {
            InitializeComponent();
            SetUpControls();
        }

        private void SetUpControls()
        {
            ViewData.Explanation = Properties.Resources.FullOuterJoinExplanation;
            ViewData.GridSource = DataAccess.GetOuterJoinData();
            ViewData.TableOneSource = DataAccess.GetTableOneSource();
            ViewData.TableTwoSource = DataAccess.GetTableTwoSource();
            ViewData.QueryUsed = App.Config.DatabaseType == GlobalStrings.DataBaseTypes.SqlLite
                ? Properties.Resources.FullOuterJoinQuerySqlite : Properties.Resources.FullOuterJoinQuery;
            DataContext = ViewData;
        }
    }
}
