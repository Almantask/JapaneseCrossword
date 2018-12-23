using System.IO;
using Newtonsoft.Json;

namespace JapaneseCrossword.Core.State
{
    public class LocalStateLoader:IStateLoader
    {
        public GameProgress Load(string path)
        {
            using (var r = new StreamReader(path))
            {
                var data = r.ReadToEnd();
                var progress = JsonConvert.DeserializeObject<GameProgress>(data);
                return progress;
            }
        }

        public void Save(GameProgress progress, string path)
        {
            using (var file = File.CreateText(path))
            {
                var jsonSerialiser = new JsonSerializer();
                jsonSerialiser.Serialize(file, progress);
            }
        }

        private string GetUniquePath(string path)
        {
            var directory = Path.GetDirectoryName(path);
            var extension = Path.GetExtension(path);
            while (File.Exists(path))
            {
                path += "1";
                var name = Path.GetFileNameWithoutExtension(path) + 1;
                path = $@"{directory}\{name}\{extension}";
            }

            return path;
        }
    }
}
