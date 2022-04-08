using NUnit.Framework;
using System.Text;

namespace Encryptors.Tests
{
    public class RsaEncryptorTests
    {
        private RsaEncryptor _rsa;
        private static readonly string _message = "This is TOP secret message";
        private static readonly byte[] _messageUTF8 = Encoding.UTF8.GetBytes(_message);
        private static byte[] _encryptedMessage;

        [SetUp]
        public void Setup()
        {
            if (_rsa == null)
            {
                _rsa = new RsaEncryptor();
                _rsa.GenerateKeysBag();
            }
        }

        [Test]
        [Order(1)]
        public void Encrypt_EncodedTestMessage_EncryptedBytesArray()
        {
            _encryptedMessage = _rsa.Encrypt(_messageUTF8);
            Assert.NotNull(_encryptedMessage);
        }

        [Test]
        [Order(2)]
        public void Decrypt_EncryptedMessageBytes_DecryptedBytesArray()
        {
            var decryptedMessage = _rsa.Decrypt(_encryptedMessage);
            var resultMessage = Encoding.UTF8.GetString(decryptedMessage);
            Assert.NotNull(resultMessage);
            Assert.AreEqual(_message, resultMessage);
        }
    }
}
