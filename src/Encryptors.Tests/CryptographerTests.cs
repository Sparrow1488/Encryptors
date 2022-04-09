using Encryptors.Abstractions;
using NUnit.Framework;
using System.Text;

namespace Encryptors.Tests
{
    public class CryptographerTests
    {
        private AesEncryptor _aes;
        private RsaEncryptor _rsa;
        private static string _message = "Test message";
        private static byte[] _encodedMessage = Encoding.UTF8.GetBytes(_message);
        private static byte[] _encryptedMessage;

        [SetUp]
        public void Setup()
        {
            if (_aes == null || _rsa == null)
            {
                _aes = new AesEncryptor();
                _aes.GenerateKeysBag();
                _rsa = new RsaEncryptor();
                _rsa.GenerateKeysBag();
            }
        }

        [Test]
        [Order(1)]
        public void Run_AesAndRsa_EncryptedBytesArray()
        {
            var sealedPipeline = Cryptographer.New().Pipeline
                                    .Use(_rsa).Use(_aes).Seal();
            _encryptedMessage = Cryptographer.New().Run(sealedPipeline, _encodedMessage)
                                .GetResult().ToBytes();
            Assert.NotNull(_encryptedMessage);
        }

        [Test]
        [Order(2)]
        public void RunBack_AesAndRsa_EncryptedBytesArray()
        {
            var sealedPipeline = Cryptographer.New().Pipeline
                                    .Use(_rsa).Use(_aes).Seal();
            var encodedMessage = Cryptographer.New().RunBack(sealedPipeline, _encryptedMessage)
                                .GetResult().ToBytes();
            string decodedMessage = Encoding.UTF8.GetString(encodedMessage);
            Assert.NotNull(_encryptedMessage);
            Assert.AreEqual(_message, decodedMessage);
        }
    }
}
