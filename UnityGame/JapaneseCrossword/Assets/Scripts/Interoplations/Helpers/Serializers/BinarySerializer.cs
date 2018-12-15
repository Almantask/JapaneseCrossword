using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Scripts.Helpers.Serializers
{
    class BinarySerializer: ISerializer
    {
        public void Serialize<T>(T data, string filePath) where T : class
        {
            if (data == null)
                return;
            bool fileExists = true;
            if (!File.Exists(filePath))
                fileExists = false;
            string result;
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);
                stream.Flush();
                stream.Position = 0;
                result = Convert.ToBase64String(stream.ToArray());
            }
            if (fileExists)
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(filePath))
                {
                    file.WriteLine(result);
                }
            }
            else
            {
                using (System.IO.StreamWriter file =
                    new StreamWriter(System.IO.File.Create(filePath)))
                {
                    file.WriteLine(result);
                }
            }
        }

        public T Deserialize<T>(string filePath) where T : class
        {
            FileStream fs = File.Open(filePath, FileMode.Open);
            string fileContents;
            using (StreamReader reader = new StreamReader(fs))
            {
                fileContents = reader.ReadToEnd();
            }
            byte[] bin = Convert.FromBase64String(fileContents);
            using (var stream = new MemoryStream(bin))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }

        public static byte[] ToByteArray<T>(T obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
