namespace Encryptors
{
    public class RsaKeysBag : KeysBag
    {
        public RsaKeysBag(byte[] publicKey, byte[] privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        public byte[] PublicKey { get; }
        public byte[] PrivateKey { get; }
    }
}
