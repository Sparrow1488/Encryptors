using Encryptors.Abstractions;
using Encryptors.Enums;
using System;
using System.Linq;

namespace Encryptors.Extended
{
    public class PipelineForSendAlgorithm
    {
        public PipelineForSendAlgorithm(CryptographerPipelineBuilder builder)
        {
            _builder = builder;
        }

        private readonly CryptographerPipelineBuilder _builder;

        public PipelineForSendAlgorithm GetMyPublicKey(Action<byte[]> publicKey)
        {
            var asymmetric = (IAsymmetricEncryptor)_builder.UsedEncryptors.First(enc => enc.GetEncryptorType() == EncryptorType.Asymmetric);
            var @public = asymmetric.GetPublicKey();
            publicKey?.Invoke(@public);
            return this;
        }

        public PipelineForSendAlgorithm DecryptSymmetricKey(
            Action<byte[]> decrypted, byte[] symmetrycKeyToDecrypt)
        {
            throw new NotImplementedException();
        }

        public PipelineForSendAlgorithm DecryptSymmetricKey(
            Action<byte[], byte[]> decrypted, byte[] firstKeyToDecrypt, byte[] secondKeyToDecrypt)
        {
            var asymmetric = (IAsymmetricEncryptor)_builder.UsedEncryptors.First(enc => enc.GetEncryptorType() == EncryptorType.Asymmetric);
            var firstKey = asymmetric.Decrypt(firstKeyToDecrypt);
            var secondKey = asymmetric.Decrypt(secondKeyToDecrypt);
            decrypted?.Invoke(firstKey, secondKey);
            return this;
        }

        public CryptographerPipelineBuilder Complete() => _builder;
    }
}
