namespace Encryptors
{
    public class AesKeysBag : KeysBag
    {
        public AesKeysBag(byte[] key, byte[] iv)
        {
            Key = key;
            IV = iv;
        }

        public byte[] Key { get; }
        public byte[] IV { get; }
    }
}
