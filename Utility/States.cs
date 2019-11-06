using compiler_of_c.Lexical_Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_of_c.Utility
{
    public static class States
    {
        public static List<State> S = new List<State>();
        public static void InitialazeStates()
        {
            S.Add(new State("Identifier", 0));
            S.Add(new State("KeyWord", 0));
            S.Add(new State("String", 0));
            S.Add(new State("Number", 0));
            S.Add(new State("Start", 0));
            S.Add(new State("Not Yet Identified", 0));
            S.Add(new State("Condition", 0));
            S.Add(new State("Done", 0));
        }

        public static void ResetProiority()
        {
            foreach (State s in S)
            {
                s.Proiority = 0;
            }
        }
    }
}
