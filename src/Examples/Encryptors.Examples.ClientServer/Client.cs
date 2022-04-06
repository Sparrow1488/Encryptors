namespace Encryptors.Examples.ClientServer
{
    internal static class Client
    {
        public readonly static RsaEncryptor RsaEncryptor = new RsaEncryptor();
        public readonly static AesEncryptor AesEncryptor = new AesEncryptor();
    }
}
