using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI.Navigation;
using SqlJoinyJoins.Services;

namespace SqlJoinyJoins
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fires whenever we navigate. We are using this for now to supply the model data to the join view models
        /// since the DX Hamburger menu would otherwise require us to set up a thorough view model, which is not necessary
        /// for the purposes of this small program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigationFrame_OnNavigated(object sender, NavigationEventArgs e)
        {

            if (e.Parameter != null)
            {
                var joinModels = new JoinModelService();
                switch (e.Parameter.ToString())
                {
                    case "Inner":
                        Messenger.Default.Send(joinModels.GetInnerJoinViewModel());
                        break;
                    case "Outer":
                        Messenger.Default.Send(joinModels.GetOuterJoinViewModel());
                        break;
                    case "Left":
                        Messenger.Default.Send(joinModels.GetLeftJoinViewModel());
                        break;
                    case "Right":
                        Messenger.Default.Send(joinModels.GetRightJoinViewModel());
                        break;
                    case "Cross":
                        Messenger.Default.Send(joinModels.GetCrossJoinViewModel());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
