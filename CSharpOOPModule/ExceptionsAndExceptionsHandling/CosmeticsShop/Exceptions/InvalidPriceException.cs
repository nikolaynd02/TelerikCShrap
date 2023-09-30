using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticsShop.Exceptions
{
    internal class InvalidPriceException : ApplicationException
    {
        public InvalidPriceException(string message) : base(message)
        {

        }
    }
}
