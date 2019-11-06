using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_of_c.Lexical_Analyzer
{
    interface IBuffer
    {
        string GetLastItem();
        string GetItem(int i);
        void ClearBuffer();
        bool ItemExists(int i);
    }
}
