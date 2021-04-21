using System;
using System.Collections.Generic;
using System.Text;

namespace Encryptors
{
    public interface IEncryptor
    {
        byte[] Encrypt(byte[] data);
        byte[] Decrypt(byte[] data);
    }
}
