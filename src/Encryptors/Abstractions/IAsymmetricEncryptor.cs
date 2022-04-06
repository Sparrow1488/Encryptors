namespace Encryptors.Abstractions
{
    public interface IAsymmetricEncryptor<TKeys> : IEncryptor<TKeys>, IAsymmetricEncryptor
        where TKeys : KeysBag
    {

    }

    public interface IAsymmetricEncryptor : IEncryptor
    {
        byte[] GetPublicKey();
        byte[] GetPrivateKey();
    }
}
