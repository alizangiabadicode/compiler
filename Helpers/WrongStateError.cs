using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_of_c.Helpers
{
    public class WrongStateError: Exception
    {
        public WrongStateError(string msg) : base(msg)
        {

        }

    }
}
