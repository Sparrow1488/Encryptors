using System;

namespace Encryptors.Abstractions
{
    public class Cryptographer
    {
        internal Cryptographer() { }

        public CryptographerPipeline Pipeline { get; private set; }

        public static Cryptographer New()
        {
            var pipe = new CryptographerPipeline();
            var crypto = new Cryptographer() {
                Pipeline = pipe
            };
            return crypto;
        }

        public Cryptographer Run(SealedCryptographerPipeline sealiedPipeline)
        {
            foreach (var encryptor in sealiedPipeline)
                encryptor.Encrypt();
            return this;
        }

        public Cryptographer RunBack(SealedCryptographerPipeline sealiedPipeline)
        {
            foreach (var encryptor in sealiedPipeline)
                encryptor.Encrypt();
            return this;
        }

        public CryptoResult GetResult()
        {
            throw new NotImplementedException();
        }

        public CryptographerPipeline GetPipeline() => Pipeline;
    }
}