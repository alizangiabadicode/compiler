using compiler_of_c.Helpers;
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
            if(ItemExists(i))
            {
                return this.Items[i];
            }
            else
            {
                throw new ItemNotFoundException("item is not found at buffer");
            }
        }

        public string GetLastItem()
        {
            if(this.Items.Count == 0)
            {
                throw new ItemNotFoundException("there is no items at all in the buffer");
            }
            else
            {
                return this.Items.Last();
            }
        }

        public bool ItemExists(int i)
        {
            string itemtoretur;
            try
            {
                itemtoretur = this.Items[i];
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
