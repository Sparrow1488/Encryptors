using Encryptors.Abstractions;
using Encryptors.Converters;
using System.Security.Cryptography;
using System.Text;

namespace Encryptors
{
    public class NewRsaEncryptor : IEncryptor<RsaKeysBag>
    {
        private readonly RsaConverter _rsaConverter = new RsaConverter();
        private readonly RSACryptoServiceProvider _rsaCryptoService = new RSACryptoServiceProvider();
        private RsaKeysBag _rsaKeysBag;

        public RsaKeysBag GetKeys() => _rsaKeysBag;

        public byte[] Decrypt(byte[] data)
        {
            var xmlPrivateKey = Encoding.UTF8.GetString(_rsaKeysBag.PrivateKey);
            var privateKey = _rsaConverter.AsParameters(xmlPrivateKey);
            _rsaCryptoService.ImportParameters(privateKey);
            return _rsaCryptoService.Decrypt(data, false);
        }

        public byte[] Encrypt(byte[] data)
        {
            var xmlPublicKey = Encoding.UTF8.GetString(_rsaKeysBag.PublicKey);
            var publicKey = _rsaConverter.AsParameters(xmlPublicKey);
            _rsaCryptoService.ImportParameters(publicKey);
            return _rsaCryptoService.Encrypt(data, false);
        }

        public RsaKeysBag GenerateKeysBag()
        {
            var privateKeyAsXml = _rsaConverter.AsXML(_rsaCryptoService.ExportParameters(true));
            var publicKeyAsXml = _rsaConverter.AsXML(_rsaCryptoService.ExportParameters(false));
            byte[] privateKeyBytes = Encoding.UTF8.GetBytes(privateKeyAsXml);
            byte[] publicKeyBytes = Encoding.UTF8.GetBytes(publicKeyAsXml);
            _rsaKeysBag = new RsaKeysBag(publicKeyBytes, privateKeyBytes);
            return _rsaKeysBag;
        }

        public void UseKeys(RsaKeysBag keys) =>
            _rsaKeysBag = keys;

        public void UseKeys(KeysBag keys) =>
            UseKeys((RsaKeysBag)keys);
    }
}
