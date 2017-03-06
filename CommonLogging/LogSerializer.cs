using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using IG.Extensions;
using Newtonsoft.Json;

namespace CommonLogging
{
    public class LogSerializer
    {
        public static string SerializeXml<TObject>(TObject objToSerialize)
        {
            string serialized;
            var serializer = new XmlSerializer(typeof(TObject));
            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, objToSerialize);
                ms.Seek(0, SeekOrigin.Begin);
                var  bytes = ms.ToArray();
                serialized = bytes.AsString();
            }
            return serialized;
        }

        public static string SerializeJson<TObject>(TObject objToSerialize)
            => JsonConvert.SerializeObject(objToSerialize, Formatting.None);

        public static string SerializeTxt<TObject>(TObject objToSerialize)
            => objToSerialize.ToString();
    }
}
