using General;
using JapaneseCrossword.Core.Rules;
using UnityEngine;
using IHintsGridBuider = JapaneseCrossword.Core.IHintsGridBuider;

namespace Assets.Scripts.CoreGame
{
    public class HintsViewBuilder : MonoBehaviour, IHintsGridBuider
    {
        [SerializeField]
        private bool _isVertical;
        [SerializeField]
        private GridSpecsGameTile _gridSpecs;
        private readonly GridBuilder<GameTile, int> _builder = new GridBuilder<GameTile, int>();

        public bool IsVertical => true;

        public void Build(int[,] gridData)
        {
            var alignedHints = IsVertical ? gridData.InvertOrientation() : gridData;
            _builder.Build(alignedHints, _gridSpecs, transform);
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

    }
}
