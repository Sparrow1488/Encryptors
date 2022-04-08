using NUnit.Framework;
using System.Text;

namespace Encryptors.Tests
{
    public class AesEncryptorTests
    {
        private AesEncryptor _aes;
        private static readonly string _message = "This is TOP secret message";
        private static readonly byte[] _messageUTF8 = Encoding.UTF8.GetBytes(_message);
        private static byte[] _encryptedMessage;

        [SetUp]
        public void Setup()
        {
            if (_aes == null)
            {
                _aes = new AesEncryptor();
                _aes.GenerateKeysBag();
            }
        }

        [Test]
        [Order(1)]
        public void Encrypt_EncodedTestMessage_EncryptedBytesArray()
        {
            _encryptedMessage = _aes.Encrypt(_messageUTF8);
            Assert.NotNull(_encryptedMessage);
        }

        [Test]
        [Order(2)]
        public void Decrypt_EncryptedMessageBytes_DecryptedBytesArray()
        {
            var decryptedMessage = _aes.Decrypt(_encryptedMessage);
            var resultMessage = Encoding.UTF8.GetString(decryptedMessage);
            Assert.NotNull(resultMessage);
            Assert.AreEqual(_message, resultMessage);
        }
    }
}