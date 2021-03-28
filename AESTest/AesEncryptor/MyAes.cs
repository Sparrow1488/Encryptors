using System.IO;
using System.Security.Cryptography;

namespace AesEncryptor
{
    public class MyAes
    {
        public static byte[] GenerateKey()
        {
            var aes = new AesManaged();
            aes.GenerateKey();
            return aes.Key;
        }
        public static byte[] GenerateIV()
        {
            var aes = new AesManaged();
            aes.GenerateIV();
            return aes.IV;
        }
        public static byte[] Encrypt(string raw, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(raw);
                        encrypted = ms.ToArray();
                    }
                }
            }
            return encrypted;
        }
        public static string Decrypt(byte[] encryptString, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream(encryptString))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
    }
}
