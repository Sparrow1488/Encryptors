namespace Encryptors.Examples.ClientServer
{
    internal static class Server
    {
        public readonly static RsaEncryptor RsaEncryptor = new RsaEncryptor();
        public readonly static AesEncryptor AesEncryptor = new AesEncryptor();
    }
}
