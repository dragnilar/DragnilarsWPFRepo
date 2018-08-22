using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SqlJoinyJoins.Annotations;
using SqlJoinyJoins.DAL;
using SqlJoinyJoins.Models;
using DevExpress.Mvvm;
using SqlJoinyJoins.Globals;

namespace SqlJoinyJoins.ViewModels
{
    public class MainWindowViewModel : NavigationViewModelBase, INotifyPropertyChanged
    {

        #region Properties

        private INavigationService NavigationService => GetService<INavigationService>();
        private bool _isMenuVisible;
        private JoinViewModelWrapper _selectedItem;

        public ObservableCollection<JoinViewModelWrapper> Items { get; set; }

        public JoinViewModelWrapper SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnSelectedItemChanged();
            }
        }

        public bool IsMenuVisible
        {
            get => _isMenuVisible;
            set
            {
                _isMenuVisible = value;
                OnPropertyChanged(nameof(IsMenuVisible));
            }
        }

        #endregion

        public MainWindowViewModel()
        {

        }

        private void OnSelectedItemChanged()
        {
            if (SelectedItem != null)
            {
                IsMenuVisible = true;
                if (NavigationService.Current is JoinViewModel viewModel)
                {
                    switch (_selectedItem.Caption)
                    {
                        case "Inner Join":
                            viewModel.SetViewData(GetInnerJoinViewModel());
                            break;
                        case "Outer Join":
                            viewModel.SetViewData(GetOuterJoinViewModel());
                            break;
                        case "Left Join":
                            viewModel.SetViewData(GetLeftJoinViewModel());
                            break;
                        case "Right Join":
                            viewModel.SetViewData(GetRightJoinViewModel());
                            break;
                        case "Cross Join":
                            viewModel.SetViewData(GetCrossJoinViewModel());
                            break;
                        default:
                            break;
                    }

                }

            }
        }




        private List<JoinViewModelWrapper> GetJoinViews()
        {
            var list = new List<JoinViewModelWrapper>
            {
                new JoinViewModelWrapper("Inner Join", "JoinView"),
                new JoinViewModelWrapper("Outer Join", "JoinView"),
                new JoinViewModelWrapper("Left Join", "JoinView"),
                new JoinViewModelWrapper("Right Join", "JoinView"),
                new JoinViewModelWrapper("Cross Join", "JoinView")
            };
            return list;
        }


        private ExampleData GetInnerJoinViewModel()
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

        private ExampleData GetOuterJoinViewModel()
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

        private ExampleData GetLeftJoinViewModel()
        {
            var data = new ExampleData
            {
                Explanation = Properties.Resources.LeftJoinExplanation,
                GridSource = DataAccess.GetLeftJoinData(),
                TableOneSource = DataAccess.GetTableOneSource(),
                TableTwoSource = DataAccess.GetTableTwoSource(),
                QueryUsed = Properties.Resources.LeftJoinQuery,
                Title = "Inner Join"
            };

            return data;

        }

        private ExampleData GetRightJoinViewModel()
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

        private ExampleData GetCrossJoinViewModel()
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


        public class JoinViewModelWrapper
        {
            public string Caption { get; set; }
            public string PageName { get; set; }
            public bool IsJoinView { get; set; }

            public JoinViewModelWrapper(string caption, string pageName)
            {
                Caption = caption;
                PageName = pageName;
            }
        }

        #region INotifyProperty And Command
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class BaseCommand : ICommand
        {
            private Predicate<object> _canExecute;
            private Action<object> _method;
            public event EventHandler CanExecuteChanged;

            public BaseCommand(Action<object> method)
            {
                _method = method;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                _method.Invoke(parameter);
            }


        }


        #endregion



    }
}



