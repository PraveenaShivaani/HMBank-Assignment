using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_14.Exceptions
{
    internal class InvalidAccountException :System.Exception
    {
        public InvalidAccountException(string message) : base(message) { }
    }
}
