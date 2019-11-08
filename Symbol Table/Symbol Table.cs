using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_of_c.Symbol_Table
{
    public class Symbol_Table
    {
        public Dictionary<string, Tuple<Type, string>> Symbols { get; set; }
        public Symbol_Table()
        {
            Symbols = new Dictionary<string, Tuple<Type, string>>();
        }

        public void Add(string name, Type type, string value)
        {
            this.Symbols.Add(name, new Tuple<Type, string>(type, value));
        }

        public bool Exists(string name)
        {
            if (name == null)
            {
                throw new Exception("name in method exits in symboltable is null");
            }
            return this.Symbols.ContainsKey(name);
        }

        public bool IsEmpty() => this.Symbols.Count == 0 ? true : false;
    }
}
