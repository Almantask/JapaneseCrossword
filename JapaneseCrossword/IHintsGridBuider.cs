namespace JapaneseCrossword
{
    public interface IHintsGridBuider
    {
        void Build(int[,] gridData);
        bool IsVertical { get; }
    }
}