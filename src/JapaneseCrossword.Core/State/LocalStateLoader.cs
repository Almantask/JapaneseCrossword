using System.IO;
using JapaneseCrossword.Core.Rules;
using Newtonsoft.Json;

namespace JapaneseCrossword.Core.State
{
    public class LocalStateLoader:IStateLoader
    {

        private JsonSerializer CreateSerializer()
        {
            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };

            return serializer;
        }

        public GameProgress Load(string path)
        {
            using (var r = new StreamReader(path))
            {
                var data = r.ReadToEnd();
                var stateModel = JsonConvert.DeserializeObject<GameStateModel>(data);
                var progress = new GameProgress(stateModel);
                return progress;
            }
        }

        public void Save(GameProgress progress, string path)
        {
            using (var sw = new StreamWriter(path))
            using (var writer = new JsonTextWriter(sw))
            {
                var serializer = CreateSerializer();
                serializer.Serialize(writer, progress);
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
