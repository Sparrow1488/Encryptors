using System;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace Encryptors.Converters
{
    public class RsaConverter
    {
        public string AsXML(RSAParameters key)
        {
            ThrowIfArgumentNullException(key);
            using (var sw = new StringWriter())
            {
                var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
                xmlSerializer.Serialize(sw, key);
                string stringKey = sw.ToString();
                return stringKey;
            }
        }

        public RSAParameters AsParameters(string xmlKey)
        {
            ThrowIfArgumentNullException(xmlKey);
            using (var sr = new StringReader(xmlKey))
            {
                var xmlDeserializer = new XmlSerializer(typeof(RSAParameters));
                var rsaKey = (RSAParameters)xmlDeserializer.Deserialize(sr);
                return rsaKey;
            }
        }

        private void ThrowIfArgumentNullException<TArg>(TArg argument)
        {
            var stringifyArgument = argument as string;
            if (argument == null || string.IsNullOrWhiteSpace(stringifyArgument))
                throw new ArgumentNullException();
        }
    }
}
