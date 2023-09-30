using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticsShop.Exceptions
{
    internal class InvalidNameException : ApplicationException
    {
        public InvalidNameException(string message):base(message)
        {

        }
    }
}
