using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SqlJoinyJoins.Annotations;
using SqlJoinyJoins.DAL;
using SqlJoinyJoins.Models;

namespace SqlJoinyJoins.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private object selectedViewModel;

        public object SelectedViewModel
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand InnerJoinCommand { get; set; }

        public MainWindowViewModel()
        {
            InnerJoinCommand = new BaseCommand(InnerJoin);
        }


        private void InnerJoin(object obj)
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
            SelectedViewModel = new JoinViewModel(data);
        }


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


    }
}



