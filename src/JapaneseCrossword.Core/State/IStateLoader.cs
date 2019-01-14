namespace JapaneseCrossword.Core.State
{
    public interface IStateLoader
    {
        GameProgress Load(string path);
        void Save(GameProgress progress, string path);
    }
}