using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace PracticeFSM
{
    class DataManager<T>
    {
        public static void Serialize(string filename, T data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writter = new StreamWriter(@"" + filename + ".xml");
            serializer.Serialize(writter, data);
            writter.Close();
        }
        public static T Deserialize(string filename)
        {
            T data;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextReader reader = new StreamReader(@"" + filename + ".xml");
            data = (T)serializer.Deserialize(reader);
            reader.Close();
            return data;
        }
    }
}