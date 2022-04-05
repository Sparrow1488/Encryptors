namespace Encryptors.Abstractions
{
    public interface ISymmetricEncryptor
    {
        byte[] GetPublicKey();
        byte[] GetPrivateKey();
    }
}
