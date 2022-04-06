using Encryptors.Abstractions;
using System;
using System.Text;

namespace Encryptors.Examples.Cryptographers
{
    public sealed class Program
    {
        private static Cryptographer _cryptographer = Cryptographer.New();
        private static KeysBag _myAesKeys;
        private static KeysBag _userAesKeys;

        private static void Main()
        {
            #region info
            // Криптографер - создает конвеер из шифровальщиков для комлпексой шифровки данных (aes256 + rsa256 + sha256 + base64)
            //                предназначен больше для удобства шифрования симметричным и не симметричным алгоритмами
            //                Также поочередно выполняет шифровку и дешифровку информации, используя добавленные в конвеер шифровальщики
            // Шифровальщик - создает ключи, шифрует и дешифрует заданным алгоритмом
            #endregion

            string message = "This is message to encrypt using AES algorithm!";
            byte[] messageInBytes = Encoding.UTF8.GetBytes(message);

            var aes256Enc = CreateAesEncryptor();
            var sealedPipe = _cryptographer.GetPipeline()
                                          .Use(aes256Enc)
                                          .Seal();
            var cryptoResult = _cryptographer.Run(sealedPipe, messageInBytes).GetResult();
            byte[] bytes = cryptoResult.ToBytes();
            Console.WriteLine("Encrypted data length: " + bytes.Length);

            cryptoResult = _cryptographer.RunBack(sealedPipe, bytes).GetResult();
            string resultMessage = Encoding.UTF8.GetString(cryptoResult.ToBytes());
            Console.WriteLine("Result => " + resultMessage);
        }

        private static IEncryptor CreateAesEncryptor()
        {
            var aes256Enc = new NewAesEncryptor();
            _myAesKeys = aes256Enc.GenerateKeysBag();
            return aes256Enc;
        }
    }
}