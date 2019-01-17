namespace JapaneseCrossword.Core
{
    public interface IHintsGridBuider
    {
        void Build(int[,] gridData);
        bool IsVertical { get; }
        void Clear();
        void Clean();
    }
}