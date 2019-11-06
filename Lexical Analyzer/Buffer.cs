using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_of_c.Lexical_Analyzer
{
    class Buffer : IBuffer
    {
        private List<string> Items = new List<string>();
        public void ClearBuffer()
        {
            this.Items.Clear();
        }

        public string GetItem(int i)
        {
            
        }

        public string GetLastItem()
        {
            throw new NotImplementedException();
        }
    }
}
