using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticsShop.Exceptions
{
    internal class InvalidBrandException : ApplicationException
    {
        public InvalidBrandException(string message) : base(message)
        {

        }
    }
}
