using System.Collections;
using System.Collections.Generic;

namespace Encryptors.Abstractions
{
    public class SealedCryptographerPipeline : IEnumerable<IEncryptor>
    {
        public SealedCryptographerPipeline(CryptographerPipeline pipeline) =>
            _pipeline = pipeline;

        private readonly CryptographerPipeline _pipeline;

        public IEnumerator<IEncryptor> GetEnumerator() => _pipeline.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _pipeline.GetEnumerator();
    }
}
