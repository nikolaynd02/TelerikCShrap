using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticsShop.Exceptions
{
    internal class InvalidCommandException : ApplicationException
    {
        public InvalidCommandException(string message) : base(message)
        {

        }
    }
}
