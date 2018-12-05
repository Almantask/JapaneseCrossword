using JapaneseCrossword.State;

namespace JapaneseCrossword.Rules
{
    public interface IRules
    {
        bool IsComplate(GameProgress progress);
    }
}
