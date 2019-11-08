using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_of_c.Lexical_Analyzer
{
    public class State : IState
    {
        public State(string name, int proiority)
        {
            Name = name;
            Proiority = proiority;
        }
        public int Proiority { get; set; }
        public string Name { get; set; }
        public bool Validity { get; set; }

        public override bool Equals(object obj)
        {
            var o = obj as State;
            if (o.Name == this.Name) return true;
            else return false;
        }
        public string Value { get; set; }
    }
}
