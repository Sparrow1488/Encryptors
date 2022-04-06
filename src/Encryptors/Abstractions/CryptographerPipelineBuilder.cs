using Encryptors.Extended;
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

        public PipelineForSendAlgorithm ForSend<TSymmetric, TAsymmetric>(TSymmetric symmetric, TAsymmetric asymmetric)
            where TSymmetric : ISymmetricEncryptor 
                where TAsymmetric : IAsymmetricEncryptor
        {
            symmetric.GenerateKeysBag();
            asymmetric.GenerateKeysBag();
            _usedEncryptors.Add(symmetric);
            _usedEncryptors.Add(asymmetric);
            _pipeline.Use(symmetric);
            return new PipelineForSendAlgorithm(this);
        }

        public CryptographerPipelineBuilder ForGet()
        {
            return this;
        }

        public CryptographerPipeline Build() =>
            _pipeline;
    }
}
