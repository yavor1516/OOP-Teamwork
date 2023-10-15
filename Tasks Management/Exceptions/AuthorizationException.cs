using System;

namespace Tasks_Management.Exceptions
{
    public class AuthorizationException : ApplicationException
    {
        public AuthorizationException(string message)
            : base(message)
        {
        }
    }
}
