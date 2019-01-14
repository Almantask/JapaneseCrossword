using JapaneseCrossword.Core.Rules;

namespace JapaneseCrossword.Core
{
    public interface IMainGridBuilder
    {
        void Build(IMonochrome[,] gridData);
        void Build(int cols, int rows);
        void Reveal(IMonochrome[,] gridData);
        void Clear();
    }
}