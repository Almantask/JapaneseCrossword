using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GridGenerator
{
    public class LocalStateLoader:IStateLoader
    {
        public CrosswordProgress Load(string path)
        {
            using (var r = new StreamReader(path))
            {
                var data = r.ReadToEnd();
                var progress = JsonConvert.DeserializeObject<CrosswordProgress>(data);
                return progress;
            }
        }

        public void Save(CrosswordProgress progress, string path)
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
