using System;

namespace BeerOverflow.Exceptions
{
    public class AuthorizationException : ApplicationException
    {
        public AuthorizationException(string message) : base(message)
        {

        }
    }
}
