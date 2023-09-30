using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticsShop.Exceptions
{
    internal class InvalidGenderException : ApplicationException
    {
        public InvalidGenderException(string message) : base(message)
        {

        }
    }
}
