using Encryptors.Abstractions;
using System;

namespace Encryptors
{
    public class Aes256Encryptor : IEncryptor, ISymmetricEncryptor
    {
        public Aes256Encryptor(string message)
        {

        }

        public Cryptographer CreateCryptographer()
        {
            throw new NotImplementedException();
        }

        public void Decrypt()
        {
            throw new NotImplementedException();
        }

        public void Encrypt()
        {
            throw new NotImplementedException();
        }

        public byte[] GetPrivateKey()
        {
            throw new NotImplementedException();
        }

        public byte[] GetPublicKey()
        {
            throw new NotImplementedException();
        }
    }
}
