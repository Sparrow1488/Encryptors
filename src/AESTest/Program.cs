using Encryptors;
using System;
using System.IO;
class ManagedAesSample
{
    public static string _path = @"yourPath";
    public static string _newFilePath = @"yourNewPath";
    public static void Main()
    {
        AesRsaEncrypt(_path, _newFilePath);
    }
    public static void AesRsaEncrypt(string path, string newPath)
    {
        if (!File.Exists(path))
            return;
        AesEncryptor aes = new AesEncryptor();
        byte[] computerData = File.ReadAllBytes(_path);
        byte[] verySecretData = aes.Encrypt(computerData);

        // * I want to send this data using unsave internet channel *
        // Firstly, i want to ask end user send me his public rsa key
        // I received on unsave channel his public rsa key

        RsaEncryptor rsa = new RsaEncryptor();
        byte[] encryptAesKey = rsa.Encrypt(aes.Key, rsa.PublicKey); // I encrypt aes key with end user rsa public key
        byte[] encryptAesIV = rsa.Encrypt(aes.IV, rsa.PublicKey);

        // I send all aes keys and verySecretData to end user and he decrypt our aes keys by his private rsa key

        byte[] decryptAesKey = rsa.Decrypt(encryptAesKey, rsa.PrivateKey);
        byte[] decryptAesIV = rsa.Decrypt(encryptAesIV, rsa.PrivateKey);
        AesEncryptor userAes = new AesEncryptor(decryptAesKey, decryptAesIV);
        byte[] finalyGetData = userAes.Decrypt(verySecretData);
        File.WriteAllBytes(_newFilePath, finalyGetData);
        Console.WriteLine("New file is exists: " + File.Exists(_newFilePath)); // Secret data was successfully sended
    }
}

