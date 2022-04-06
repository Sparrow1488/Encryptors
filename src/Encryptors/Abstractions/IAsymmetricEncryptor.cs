namespace Encryptors.Abstractions
{
    public interface IAsymmetricEncryptor
    {
        byte[] GetPublicKey();
        byte[] GetPrivateKey();
    }
}
