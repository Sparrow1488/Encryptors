using System;

namespace Encryptors.Exceptions
{
    public class KeysNotSetException : Exception
    {
        public KeysNotSetException() { }

        public override string Message => "Encryprion keys not set in the encryptor";
    }
}
