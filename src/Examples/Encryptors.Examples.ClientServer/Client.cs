namespace Encryptors.Examples.ClientServer
{
    internal static class Client
    {
        public readonly static NewRsaEncryptor RsaEncryptor = new NewRsaEncryptor();
        public readonly static NewAesEncryptor AesEncryptor = new NewAesEncryptor();
    }
}
