using Assets.Scripts.CoreGame;
using JapaneseCrossword.Core;

namespace Assets.Scripts.SceneManagement
{
    internal class VerticalHintsBuilder : GridBuilder<HintTile>, IHintsGridBuider
    {
        public void Build(int[,] gridData)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool IsVertical { get; }
    }
}