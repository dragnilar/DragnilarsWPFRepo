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
using SqlJoinyJoins.DAL;
using SqlJoinyJoins.Globals;
using SqlJoinyJoins.Models;

namespace SqlJoinyJoins.Views
{
    /// <summary>
    /// Interaction logic for CrossJoinView.xaml
    /// </summary>
    public partial class CrossJoinView : UserControl
    {
        public ExampleData ViewData = new ExampleData();
        public CrossJoinView()
        {
            InitializeComponent();
            SetUpControls();
        }

        private void SetUpControls()
        {
            ViewData.Explanation = Properties.Resources.CrossJoinExplanation;
            ViewData.GridSource = DataAccess.GetCrossJoinData();
            ViewData.TableOneSource = DataAccess.GetTableOneSource();
            ViewData.TableTwoSource = DataAccess.GetTableTwoSource();
            ViewData.QueryUsed = Properties.Resources.CrossJoinQuery;
            DataContext = ViewData;
        }
    }
}
