using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JapaneseCrossword.State;

namespace JapaneseCrossword.Rules
{
    public interface IRules
    {
        bool IsComplate(GameProgress progress);
    }
}
