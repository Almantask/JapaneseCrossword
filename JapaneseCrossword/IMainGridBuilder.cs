using JapaneseCrossword.Rules;

namespace JapaneseCrossword
{
    public interface IMainGridBuilder
    {
        void Build(IMonochrome[,] gridData);
    }
}