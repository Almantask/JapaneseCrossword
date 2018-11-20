namespace GridGenerator
{
    public interface IStateLoader
    {
        CrosswordProgress Load(string path);
        void Save(CrosswordProgress progress, string path);
    }
}