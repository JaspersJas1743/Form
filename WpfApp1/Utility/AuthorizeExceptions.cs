using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utility
{
    class AuthorizeExceptions: Exception
    {
        public AuthorizeExceptions(string message = "Incorrect data!") : base(message)
        {}
    }
}
