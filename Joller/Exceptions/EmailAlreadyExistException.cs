using System;

namespace Joller.Exceptions
{
    public class EmailAlreadyExistException : Exception
    {
        public EmailAlreadyExistException(String email) : base(email)
        {

        }
    }
}