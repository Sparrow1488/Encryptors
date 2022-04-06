namespace Encryptors.Abstractions
{
    public interface IEncryptor<TKeys> : IEncryptor
        where TKeys : KeysBag
    {
        TKeys GenerateKeysBag();
        void UseKeys(TKeys keys);
        TKeys GetKeys();
    }

    public interface IEncryptor
    {
        byte[] Encrypt(byte[] data);
        byte[] Decrypt(byte[] data);
        void UseKeys(KeysBag keys);
    }
}
