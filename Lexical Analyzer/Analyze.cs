using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using compiler_of_c.Utility;
namespace compiler_of_c.Lexical_Analyzer
{
    class Analyze
    {
        public async void Start(string txt)
        {
            // aval state miad ru start
            State state = States.S.First(e => e.Name == "Start");

            foreach (char c in txt)
            {

            }
        }
    }
}
