using System.IO;
using System.Xml.Serialization;

namespace Assets.Scripts.Interoplations.Helpers.Serializers
{
    class XMLSerializer : ISerializer
    {
        public T Deserialize<T>(string filePath) where T : class
        {
            T savedData;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(filePath);
            savedData = (T)serializer.Deserialize(reader);
            reader.Close();
            return savedData;
        }

        public void Serialize<T>(T data, string filePath) where T : class
        {
            bool fileExists = false;
            if (data == null)
                return;
            if (!File.Exists(filePath))
                fileExists = false;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writer;
            if(fileExists)
                writer = new StreamWriter(filePath);
            else
                writer = new StreamWriter(System.IO.File.Create(filePath));
            serializer.Serialize(writer, data);
            writer.Close();
        }
    }
}
