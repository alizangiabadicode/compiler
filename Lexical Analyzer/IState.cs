using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_of_c.Lexical_Analyzer
{
    interface IState
    {
        string Name { get; set; }
        bool Validity { get; set; }
    }
}
