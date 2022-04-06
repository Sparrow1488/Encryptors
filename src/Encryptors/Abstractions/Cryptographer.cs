using System.Linq;

namespace Encryptors.Abstractions
{
    public class Cryptographer
    {
        internal Cryptographer() { }

        public CryptographerPipeline Pipeline { get; private set; }

        private CryptoResult _result;

        public static Cryptographer New()
        {
            var pipe = new CryptographerPipeline();
            var crypto = new Cryptographer() {
                Pipeline = pipe
            };
            return crypto;
        }

        public Cryptographer Run(SealedCryptographerPipeline sealiedPipeline, byte[] dataToComplexEncrypt)
        {
            byte[] encryptedData = dataToComplexEncrypt;
            foreach (var encryptor in sealiedPipeline)
                encryptedData = encryptor.Encrypt(encryptedData);
            _result = new CryptoResult(encryptedData);
            return this;
        }

        public Cryptographer RunBack(SealedCryptographerPipeline sealiedPipeline, byte[] dataToDecrypt)
        {
            byte[] encryptedData = dataToDecrypt;
            foreach (var encryptor in sealiedPipeline.Reverse())
                encryptedData = encryptor.Decrypt(encryptedData);
            _result = new CryptoResult(encryptedData);
            return this;
        }

        public CryptoResult GetResult() =>
            _result;

        public CryptographerPipeline GetPipeline() => Pipeline;
    }
}