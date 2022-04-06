using System;
using System.Collections;
using System.Collections.Generic;

namespace Encryptors.Abstractions
{
    public class CryptographerPipeline : IEnumerable<IEncryptor>
    {
        public CryptographerPipeline()
        {
            _encryptorsList = new List<IEncryptor>();
        }

        private IList<IEncryptor> _encryptorsList;

        public CryptographerPipeline Use<TEncryptor>(TEncryptor encryptor)
            where TEncryptor : IEncryptor
        {
            _encryptorsList.Add(encryptor);
            return this;
        }

        public SealedCryptographerPipeline Seal() => new SealedCryptographerPipeline(this);

        public IEnumerator<IEncryptor> GetEnumerator() => _encryptorsList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _encryptorsList.GetEnumerator();
    }
}
