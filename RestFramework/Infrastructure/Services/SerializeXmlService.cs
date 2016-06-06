using Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SerializeXmlService<T> : ISerializeService<T>
    {
        /// <summary>
        /// Deserializes the XML document contained by the specified data string 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize(string data)
        {
            using (System.IO.StringReader sr = new System.IO.StringReader(data))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(sr);
            }
        }

        /// <summary>
        /// Serializes the specified data and writes the XML document
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Serialize(T data)
        {
            using (System.IO.TextWriter writer = new System.IO.StringWriter())
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                serializer.Serialize(writer, data);
                return writer.ToString();
            } 
        }
    }
}
