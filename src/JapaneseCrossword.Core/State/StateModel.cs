using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossword.Core.State
{
    /// <summary>
    /// TODO: refactor to bools.
    /// </summary>
    public class GameStateModel
    {
        public Fillable[,] Goal { set; get; }
        public Fillable[,] Current { set; get; }
    }
}
