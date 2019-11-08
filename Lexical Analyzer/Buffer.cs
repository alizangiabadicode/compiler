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
        private List<char> Items = new List<char>();

        public void Add(char character)
        {
            this.Items.Add(character);
        }

        public string GetString()
        {
            return string.Join("", Items);
        }

        public void ClearBuffer()
        {
            this.Items.Clear();
        }

        public char GetItem(int i)
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

        public char GetLastItem()
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
            char itemtoretur;
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
