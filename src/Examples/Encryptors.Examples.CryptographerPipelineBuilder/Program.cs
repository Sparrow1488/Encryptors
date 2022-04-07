using Encryptors.Abstractions;
using System;
using System.Text;

namespace Encryptors.Examples.CryptographerPipelineBuilder
{
    internal sealed class Program
    {
        private static readonly string _secretMessage = "Secret message";

        private static readonly AesEncryptor _aesEncryptor = new AesEncryptor();
        private static readonly RsaEncryptor _rsaEncryptor = new RsaEncryptor();
        private static readonly Cryptographer _cryptographer = Cryptographer.New();

        private static byte[] _encryptedAesKey;
        private static byte[] _encryptedAesIV;

        private static void Main()
        {
            InitAesEncryptor();
            InitRsaEncryptor();
            SenderWorks();
        }

        private static void GetterWorks()
        {

        }

        private static void SenderWorks()
        {
            var publicKeyWhatISent = new byte[0];
            var algorithm = _cryptographer.GetBuilder()
                                         .ForSend(_aesEncryptor, _rsaEncryptor)
                                         .GetMyPublicKey(key => publicKeyWhatISent = key);

            // Send my public key

            EncryptAesKeys(); // [client] encrypt using my public key (RSA)
            // [client] Get encrypted aes key

            byte[] decryptedAesKey;
            byte[] decryptedAesIV;
            var sealedPipeline = algorithm.DecryptSymmetricKey((key, iv) =>
            {
                decryptedAesKey = key;
                decryptedAesIV = iv;
            }, _encryptedAesKey, _encryptedAesIV).Complete().Build().Seal();

            var encryptedData = _cryptographer.Run(sealedPipeline, GetEncodedMessage())
                                              .GetResult().ToBytes();

            // Send encryptedData



            // [client] decrypt my message
            var decrypted = _aesEncryptor.Decrypt(encryptedData);
            string message = GetDecodedMessage(decrypted);
            Console.WriteLine(message);
        }

        private static AesEncryptor InitAesEncryptor()
        {
            _aesEncryptor.GenerateKeysBag();
            return _aesEncryptor;
        }

        private static RsaEncryptor InitRsaEncryptor()
        {
            _rsaEncryptor.GenerateKeysBag();
            return _rsaEncryptor;
        }

        private static void EncryptAesKeys()
        {
            var key = _aesEncryptor.GetKeys().Key;
            var iv = _aesEncryptor.GetKeys().IV;
            _encryptedAesKey = _rsaEncryptor.Encrypt(key);
            _encryptedAesIV = _rsaEncryptor.Encrypt(iv);
        }

        private static byte[] GetEncodedMessage() => 
            Encoding.UTF8.GetBytes(_secretMessage);

        private static string GetDecodedMessage(byte[] data) =>
            Encoding.UTF8.GetString(data);
    }
}
