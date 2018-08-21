using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlJoinyJoins.Models;

namespace SqlJoinyJoins.ViewModels
{
    public class JoinViewModel : INotifyPropertyChanged
    {
        private DataView _gridSource;
        private DataView _tableOneSource;
        private DataView _tableTwoSource;
        private string _explanation;
        private string _queryUsed;
        private string _title;

        public JoinViewModel(ExampleData data)
        {
            _gridSource = data.GridSource;
            _tableOneSource = data.TableOneSource;
            _tableTwoSource = data.TableTwoSource;
            _queryUsed = data.QueryUsed;
            _explanation = data.Explanation;
        }

        public DataView GridSource
        {
            get => _gridSource;
            set
            {
                _gridSource = value;
                NotifyChanges(this, new PropertyChangedEventArgs("GridSource"));
            }
        }

        public DataView TableOneSource
        {
            get => _tableOneSource;
            set
            {
                _tableOneSource = value;
                NotifyChanges(this, new PropertyChangedEventArgs("TableOneSource"));
            }
        }

        public DataView TableTwoSource
        {
            get => _tableTwoSource;
            set
            {
                _tableTwoSource = value;
                NotifyChanges(this, new PropertyChangedEventArgs("TableTwoSource"));
            }
        }

        public string Explanation
        {
            get => _explanation;
            set
            {
                _explanation = value;
                NotifyChanges(this, new PropertyChangedEventArgs("Explanation"));
            }
        }

        public string QueryUsed
        {
            get => _queryUsed;
            set
            {
                _queryUsed = value;
                NotifyChanges(this, new PropertyChangedEventArgs("QueryUsed"));
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NotifyChanges(this, new PropertyChangedEventArgs("QueryUsed"));
            }
        }


        private void NotifyChanges(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != null)
            {
                PropertyChanged (this, new PropertyChangedEventArgs(e.PropertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
