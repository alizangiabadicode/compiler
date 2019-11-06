using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_of_c.Helpers
{
    class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string msg): base(msg)
        {

        }
    }
}
