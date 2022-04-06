using Encryptors.Abstractions;
using Encryptors.Enums;
using Encryptors.Exceptions;
using System.IO;
using System.Security.Cryptography;

namespace Encryptors
{
    public class AesEncryptor : ISymmetricEncryptor<AesKeysBag>
    {
        private AesKeysBag _aesKeyBag;
        private AesManaged _managed = new AesManaged();

        public int KeySize => _managed.KeySize;
        public AesKeysBag GetKeys() => _aesKeyBag;

        public AesKeysBag GenerateKeysBag()
        {
            var key = GenerateKey();
            var iv = GenerateIV();
            _aesKeyBag = new AesKeysBag(key, iv);
            return _aesKeyBag;
        }

        public byte[] Decrypt(byte[] data)
        {
            ThrowIfKeysAreEmpty();
            byte[] result;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(_aesKeyBag.Key, _aesKeyBag.IV);
                using (MemoryStream ms = new MemoryStream(data))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        result = decryptor.TransformFinalBlock(data, 0, data.Length);
                }
            }
            return result;
        }

        public byte[] Encrypt(byte[] data)
        {
            ThrowIfKeysAreEmpty();
            byte[] encrypted = new byte[0];
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(_aesKeyBag.Key, _aesKeyBag.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        encrypted = encryptor.TransformFinalBlock(data, 0, data.Length);
                }
            }
            return encrypted;
        }

        public void UseKeys(AesKeysBag keys) =>
            _aesKeyBag = keys;

        public void UseKeys(KeysBag keys) => UseKeys((AesKeysBag)keys);

        private byte[] GenerateKey()
        {
            _managed.GenerateKey();
            return _managed.Key;
        }

        private byte[] GenerateIV()
        {
            _managed.GenerateIV();
            return _managed.IV;
        }

        private void ThrowIfKeysAreEmpty()
        {
            if (_aesKeyBag == null || _aesKeyBag.Key == null || _aesKeyBag.IV == null)
                throw new KeysNotSetException();
        }

        public EncryptorType GetEncryptorType() => EncryptorType.Symmetric;
        void IEncryptor.GenerateKeysBag() => GenerateKeysBag();
    }
}
