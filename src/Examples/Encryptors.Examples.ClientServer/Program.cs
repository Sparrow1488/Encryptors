using System;
using System.Text;

namespace Encryptors.Examples.ClientServer
{
    internal sealed class Program
    {
        #region Information
        /*
            1. Указать протокол с шифрованием (в данном примере не имеет значения)
            2. Подтвердить протокол с сервером (в данном примере не имеет значения)
            3. Получить от сервера публичный RSA ключ
            4. Зашифровать свой AES ключ
            5. Отправить зашифрованный AES ключ серверу
            6. Сервер дешифрует при помощи приватного ключа RSA -> получает AES ключ
            7. Сервер шифрует информацию при помощи AES
            8. Отправляет клиенту зашифрованный пакет
            9. Клиент получает пакет и дешифрует при помощи AES ключа, который хранился только у него
         */
        #endregion

        private static readonly string _messageToExchange = "TOP SECRET INFORMATION! NOT FOR ALL!";

        private static void Main()
        {
            GenerateKeysOnTwoSides();
            var serverPublicRsa = Server.RsaEncryptor.GetKeys().PublicKey;
            // Сервер отправляет

            // Клиент получает
            var clientAesKeys = Client.AesEncryptor.GetKeys();
            Client.RsaEncryptor.UseKeys(new RsaKeysBag(serverPublicRsa, null));
            var aesEncryptedKey = Client.RsaEncryptor.Encrypt(clientAesKeys.Key);
            var aesEncryptedIV = Client.RsaEncryptor.Encrypt(clientAesKeys.IV);
            // Клиент отправляет

            // Сервер получает
            var aesDecryptedKey = Server.RsaEncryptor.Decrypt(aesEncryptedKey);
            var aesDecryptedIV = Server.RsaEncryptor.Decrypt(aesEncryptedIV);
            Server.AesEncryptor.UseKeys(new AesKeysBag(aesDecryptedKey, aesDecryptedIV));
            var encryptedSecretMessage = Server.AesEncryptor.Encrypt(GetEncodedSecretMessage());
            // Сервер отправляет

            // Клиент получает
            var decryptedSecretMessage = Client.AesEncryptor.Decrypt(encryptedSecretMessage);
            var decodedMessage = GetDecodedSecretMessage(decryptedSecretMessage);
            Console.WriteLine(decodedMessage);
        }

        private static void GenerateKeysOnTwoSides()
        {
            Client.AesEncryptor.GenerateKeysBag();
            Server.AesEncryptor.GenerateKeysBag();

            Client.RsaEncryptor.GenerateKeysBag();
            Server.RsaEncryptor.GenerateKeysBag();
        }

        private static byte[] GetEncodedSecretMessage() =>
            Encoding.UTF8.GetBytes(_messageToExchange);

        private static string GetDecodedSecretMessage(byte[] messageInBytes) =>
            Encoding.UTF8.GetString(messageInBytes);
    }
}
