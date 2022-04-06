namespace Encryptors.Examples.ClientServer
{
    internal static class Server
    {
        public readonly static NewRsaEncryptor RsaEncryptor = new NewRsaEncryptor();
        public readonly static NewAesEncryptor AesEncryptor = new NewAesEncryptor();
    }
}
