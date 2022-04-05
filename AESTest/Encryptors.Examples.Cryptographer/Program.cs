using Encryptors.Abstractions;

namespace Encryptors.Examples.Cryptographers
{
    public sealed class Program
    {
        private static void Main()
        {
            // Криптографер - создает конвеер из шифровальщиков для комлпексой шифровки данных (aes256 + rsa256 + sha256 + base64)
            //                предназначен больше для удобства шифрования симметричным и не симметричным алгоритмами
            //                Также поочередно выполняет шифровку и дешифровку информации, используя добавленные в конвеер шифровальщики
            // Шифровальщик - создает ключи, шифрует и дешифрует заданным алгоритмом

            string message = "This is message to encrypt using AES254 algorithm!";
            var aes256Enc = new Aes256Encryptor(message);
            var cryptographer = Cryptographer.New();
            var sealedPipe = cryptographer.GetPipeline()
                                          .Use(aes256Enc)
                                          .Seal();
            var cryptoResult = cryptographer.Run(sealedPipe).GetResult();
            string base64 = cryptoResult.ToBase64();
            byte[] bytes = cryptoResult.ToBytes();

            cryptoResult = cryptographer.RunBack(sealedPipe).GetResult();
        }
    }
}
