using System;

namespace Encryptors
{
    public class CryptoResult
    {
        // TODO: 2 инкапсулированных состояния - хранит зашифрованные данные, либо расшифрованные
        public CryptoResult(byte[] encryptedData) =>
            _encryptedData = encryptedData;

        private readonly byte[] _encryptedData;

        public string ToBase64() =>
            Convert.ToBase64String(_encryptedData);

        public byte[] ToBytes() =>
            _encryptedData;
    }
}
