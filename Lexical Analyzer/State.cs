using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_of_c.Lexical_Analyzer
{
    class State : IState
    {
        public string Name { get; set; }
        public bool Validity { get; set; }
    }
}
