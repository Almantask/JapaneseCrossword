using JapaneseCrossword.Core.Rules;

namespace JapaneseCrossword.Core
{
    public interface IMainGridBuilder
    {
        void Build(IMonochrome<ColorChangedEventArgs>[,] gridData);
        void Build(int cols, int rows);
        void Reveal(IMonochrome<ColorChangedEventArgs>[,] gridData);
        void Clear();
        void Clean();
    }
}