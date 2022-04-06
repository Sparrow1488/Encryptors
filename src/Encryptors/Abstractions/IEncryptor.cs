using Encryptors.Enums;

namespace Encryptors.Abstractions
{
    public interface IEncryptor<TKeys> : IEncryptor
        where TKeys : KeysBag
    {
        new TKeys GenerateKeysBag();
        void UseKeys(TKeys keys);
        TKeys GetKeys();
    }

    public interface IEncryptor
    {
        byte[] Encrypt(byte[] data);
        byte[] Decrypt(byte[] data);
        void UseKeys(KeysBag keys);
        EncryptorType GetEncryptorType();
        void GenerateKeysBag();
    }
}
