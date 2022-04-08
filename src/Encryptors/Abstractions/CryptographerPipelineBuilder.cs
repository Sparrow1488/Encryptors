using System.Collections.Generic;

namespace Encryptors.Abstractions
{
    public class CryptographerPipelineBuilder
    {
        public CryptographerPipelineBuilder(CryptographerPipeline pipeline) =>
            _pipeline = pipeline;

        private readonly CryptographerPipeline _pipeline;
        private readonly IList<IEncryptor> _usedEncryptors = new List<IEncryptor>();

        public IEnumerable<IEncryptor> UsedEncryptors => _usedEncryptors;

        public CryptographerPipeline Build() =>
            _pipeline;
    }
}
