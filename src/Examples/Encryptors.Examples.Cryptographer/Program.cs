using Encryptors.Abstractions;
using System;
using System.Text;

namespace Encryptors.Examples.Cryptographers
{
    public sealed class Program
    {
        private static Cryptographer _cryptographer = Cryptographer.New();
        private static Encoding _encoding = Encoding.UTF8;

        private static void Main()
        {
            // Prepare data and encryptors
            string message = "This is message to encrypt using AES algorithm!";
            byte[] messageInBytes = _encoding.GetBytes(message);
            var aes256Enc = CreateAesEncryptor();
            var rsa256Enc = CreateRsaEncryptor();

            // Create crypto-pipeline
            var sealedPipe = _cryptographer.GetPipeline()
                                            .Use(aes256Enc)
                                             .Use(rsa256Enc)
                                              .Seal();

            // Encrypt
            var cryptoResult = _cryptographer.Run(sealedPipe, messageInBytes).GetResult();
            byte[] bytes = cryptoResult.ToBytes();
            Console.WriteLine("Encrypted Message Length => " + bytes.Length.ToString());

            // Decrypt
            cryptoResult = _cryptographer.RunBack(sealedPipe, bytes).GetResult();
            string resultMessage = _encoding.GetString(cryptoResult.ToBytes());
            Console.WriteLine("Decrypted message => " + resultMessage);
        }

        private static IEncryptor CreateAesEncryptor()
        {
            var aes256Enc = new AesEncryptor();
            aes256Enc.GenerateKeysBag();
            return aes256Enc;
        }

        private static IEncryptor CreateRsaEncryptor()
        {
            var rsa256Enc = new RsaEncryptor();
            rsa256Enc.GenerateKeysBag();
            return rsa256Enc;
        }
    }
}