using Encryptors.Abstractions;
using System.Security.Cryptography;

namespace Encryptors
{
    public class RsaEncryptor : IEncryptor
    {
        public RsaEncryptor()
        {
            GenerateKeys();
        }
        public int KeyLenght { get; private set; } = 2048;
        private RSACryptoServiceProvider CSP;
        public RSAParameters PrivateKey { get; private set; }
        public RSAParameters PublicKey { get; private set; }

        public void GenerateKeys()
        {
            CSP = new RSACryptoServiceProvider();
            PrivateKey = CSP.ExportParameters(true);
            PublicKey = CSP.ExportParameters(false);
        }
        public byte[] Decrypt(byte[] data, RSAParameters privateKey)
        {
            return DefaultDecrypt(data, privateKey);
        }
        public byte[] Encrypt(byte[] data, RSAParameters publicKey)
        {
            return DefaultEncrypt(data, publicKey);
        }
        private byte[] DefaultDecrypt(byte[] encData, RSAParameters privateKey)
        {
            CSP.ImportParameters(privateKey);
            return CSP.Decrypt(encData, false);
        }
        private byte[] DefaultEncrypt(byte[] data, RSAParameters publicKey)
        {
            CSP.ImportParameters(publicKey);
            return CSP.Encrypt(data, false);
        }

        public byte[] Encrypt(byte[] data)
        {
            throw new System.NotImplementedException();
        }

        public byte[] Decrypt(byte[] data)
        {
            throw new System.NotImplementedException();
        }

        public void UseKeys(KeysBag keys)
        {
            throw new System.NotImplementedException();
        }
    }
}
