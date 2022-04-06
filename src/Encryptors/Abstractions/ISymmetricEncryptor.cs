namespace Encryptors.Abstractions
{
    public interface ISymmetricEncryptor<TKeys> : IEncryptor<TKeys>, ISymmetricEncryptor
        where TKeys : KeysBag
    { 

    }

    public interface ISymmetricEncryptor : IEncryptor 
    { 

    }
}
