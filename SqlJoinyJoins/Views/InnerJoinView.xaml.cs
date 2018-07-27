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
using SqlJoinyJoins.Globals;
using SqlJoinyJoins.Models;

namespace SqlJoinyJoins.Views
{
    /// <summary>
    /// Interaction logic for InnerJoinView.xaml
    /// </summary>
    public partial class InnerJoinView : UserControl
    {
        public ExampleData ViewData = new ExampleData();

        public InnerJoinView()
        {
            InitializeComponent();
            SetUpControls();
        }

        private void SetUpControls()
        {
            ViewData.Explanation = Properties.Resources.FullInnerJoinExplanation;
            ViewData.GridSource = DataAccess.GetInnerJoinData();
            ViewData.TableOneSource = DataAccess.GetTableOneSource();
            ViewData.TableTwoSource = DataAccess.GetTableTwoSource();
            ViewData.QueryUsed = Properties.Resources.FullInnerJoinQuery;
            DataContext = ViewData;
        }
    }
}
