using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlJoinyJoins.Models
{
    public class ServerTypeItem
    {
        public ServerTypeItem(string displayValue, string type)
        {
            ServerType = type;
            DisplayValue = displayValue;
        }

        public string ServerType { get; private set; }
        public string DisplayValue { get; private set; }
    }
}
