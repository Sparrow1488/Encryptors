using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace Encryptors.Rsa
{
    public class RsaConverter
    {
        public string AsXML(RSAParameters key)
        {
            var sw = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(sw, key);
            string stringKey = sw.ToString();
            return stringKey;
        }

        public RSAParameters AsParameters(string xmlKey)
        {
            var sr = new StringReader(xmlKey);
            var xmlDeserializer = new XmlSerializer(typeof(RSAParameters));
            var rsaKey = (RSAParameters)xmlDeserializer.Deserialize(sr);
            return rsaKey;
        }
    }
}
