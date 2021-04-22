using Encryptors.Rsa;
using Encryptors.RSA.Exceptions;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Encryptors.Rsa
{
    //public class RsaEncryptor : IEncryptor
    //{
    //    public RsaEncryptor(RSAParameters publicKey, RSAParameters privateKey)
    //    {
    //        PublicKey = publicKey;
    //        PrivateKey = privateKey;
    //        //KeyLenght = keySize;
    //        CSP = new RSACryptoServiceProvider(KeyLenght);
    //    }
    //    public RsaEncryptor(string xmlPublicKey, string xmlPrivateKey, int keySize)
    //    {
    //        RsaConverter converter = new RsaConverter();
    //        PublicKey = converter.AsParameters(xmlPublicKey);
    //        PrivateKey = converter.AsParameters(xmlPrivateKey);
    //        KeyLenght = keySize;
    //        CSP = new RSACryptoServiceProvider(KeyLenght);
    //    }
    //    public RsaEncryptor()
    //    {
    //        CSP = new RSACryptoServiceProvider(KeyLenght);
    //        PrivateKey = CSP.ExportParameters(true);
    //        PublicKey = CSP.ExportParameters(false);
    //    }

    //    public RSAParameters PublicKey { get; private set; }
    //    public RSAParameters PrivateKey { get; private set; }
    //    public int KeyLenght { get; private set; } = 2048;
    //    private RSACryptoServiceProvider CSP;

    //    /// <summary>
    //    /// Дешифрует данные по заданным при инициализации ключам
    //    /// </summary>
    //    /// <param name="data"></param>
    //    /// <exception cref="DecryptException">Ошибка дешифрования данных</exception>
    //    /// <returns></returns>
    //    public byte[] Decrypt(byte[] data)
    //    {
    //        if (CanDecrypt(data))
    //        {
    //            CSP.ImportParameters(PrivateKey);
    //            var _decryptData = CSP.Decrypt(data, false);
    //            return _decryptData;
    //        }
    //        else throw new DecryptException("Ошибка дешифровки данных. Возможно, Вы использовали невалидные ключи");
    //    }

    //    public byte[] Encrypt(byte[] data)
    //    {
    //        try
    //        {
    //            return DefaultEncrypt(data);
    //        }
    //        catch (Exception) { }
    //    }
    //    private bool CanDecrypt()
    //    {
    //        try
    //        {
    //            byte[] testEnc = DefaultEncrypt(Encoding.UTF8.GetBytes("Че"));
    //            DefaultDecrypt(testEnc);
    //            return true;
    //        }
    //        catch (Exception) { return false; }
    //    }
    //    private bool CanEncrypt(byte[] data)
    //    {
    //        try
    //        {
    //            byte[] testDec = DefaultDecrypt(Encoding.UTF8.GetBytes("Че"));
    //            DefaultEncrypt(data);
    //            return true;
    //        }
    //        catch (Exception) { return false; }
    //    }
    //    private byte[] DefaultDecrypt(byte[] encData)
    //    {
    //        CSP.ImportParameters(PrivateKey);
    //        return CSP.Decrypt(encData, false);
    //    }
    //    private byte[] DefaultEncrypt(byte[] data)
    //    {
    //        CSP.ImportParameters(PublicKey);
    //        return CSP.Encrypt(data, false);
    //    }
    //}
}
