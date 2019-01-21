using JapaneseCrossword.Core.State;

namespace JapaneseCrossword.Core.Rules
{
    public interface IRules
    {
        bool IsComplete(GameProgress progress);
    }
}
