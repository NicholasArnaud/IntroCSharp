using System.IO;
using System.Xml.Serialization;

namespace FSMAssessment
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
