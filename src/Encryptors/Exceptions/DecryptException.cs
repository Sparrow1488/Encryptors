using System;
using System.Collections.Generic;
using System.Text;

namespace Encryptors.RSA.Exceptions
{
    public class DecryptException : Exception
    {
        public DecryptException(string message) : base(message)
        {
        }
    }
}
