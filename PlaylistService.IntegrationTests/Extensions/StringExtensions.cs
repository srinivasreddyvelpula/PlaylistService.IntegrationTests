using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PlaylistService.IntegrationTests.Extensions
{
    public static class StringExtensions
    {
        public static object DeserializeContractObject(this string xml, Type type)
        {
            var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(xml));
            using (var reader = XmlDictionaryReader.CreateTextReader(memoryStream, Encoding.Unicode, new XmlDictionaryReaderQuotas(), null))
            {
                DataContractSerializer dataContractSerializer = new DataContractSerializer(type);
                return dataContractSerializer.ReadObject(reader);
            }
        }
    }
}
