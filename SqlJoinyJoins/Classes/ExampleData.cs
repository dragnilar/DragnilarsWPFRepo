using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlJoinyJoins.Classes
{
    public class ExampleData
    {
        public string Explanation { get; set; }

        public string QueryUsed { get; set; }

        public DataView GridSource { get; set; }

        public DataView TableOneSource { get; set; }

        public DataView TableTwoSource { get; set; }
    }
}
