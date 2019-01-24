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
