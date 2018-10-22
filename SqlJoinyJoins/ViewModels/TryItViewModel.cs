using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SqlJoinyJoins.Annotations;
using SqlJoinyJoins.DAL;

namespace SqlJoinyJoins.ViewModels
{
    public class TryItViewModel : INotifyPropertyChanged
    {
        private string _queryText;
        private DataView _queryResultsTable;
        private readonly bool _canExecute = true;
        private ICommand _clearCommand;
        private ICommand _runQueryCommand;

        public string QueryText
        {
            get => _queryText;
            set
            {
                if (value == _queryText) return;
                _queryText = value;
                OnPropertyChanged();
            }
        }

        public DataView QueryResultsTable
        {
            get => _queryResultsTable;
            set
            {
                if (Equals(value, _queryResultsTable)) return;
                _queryResultsTable = value;
                OnPropertyChanged();
            }
        }

        public ICommand RunQueryCommand => _runQueryCommand ?? (_runQueryCommand = new TryItCommand(RunQuery, _canExecute));
        public ICommand ClearCommand => _clearCommand ?? (_clearCommand = new TryItCommand(ClearView, _canExecute));

        public void ClearView()
        {
            QueryText = string.Empty;
            QueryResultsTable = null;
        }

        public void RunQuery()
        {
            if (!string.IsNullOrWhiteSpace(QueryText))
            {
               var result = DataAccess.GetTableForCustomQuery(QueryText);

                if (result.result != null)
                {
                    QueryResultsTable = result.result;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class TryItCommand : ICommand
        {
            private readonly Action _action;
            private readonly bool _canExecute;

            public TryItCommand(Action action, bool canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public void Execute(object parameter)
            {
                _action();
            }

            public event EventHandler CanExecuteChanged;
        }
    }
}
