using System.Data;

namespace SqlJoinyJoins.Models
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
