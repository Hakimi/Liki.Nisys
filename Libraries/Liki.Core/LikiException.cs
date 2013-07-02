using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liki.Core
{

    public class LikiException : Exception
    {
        public LikiException(string message)
            : base(message)
        {
        }
    }
}
