using General;
using JapaneseCrossword.Core.Rules;
using UnityEngine;
using IHintsGridBuider = JapaneseCrossword.Core.IHintsGridBuider;

namespace Assets.Scripts.CoreGame
{
    public class HintsViewBuilder : MonoBehaviour, IHintsGridBuider
    {
        [SerializeField]
        private GridSpecsHintTile _gridSpecs;

        [SerializeField]
        private bool _isVertical;

        private readonly GridBuilder<HintTile, int> _builder = new GridBuilder<HintTile, int>();

        public void SetPivot(Vector2 pivot, Edge edge)
        {
            _gridSpecs.SetPivotPoint(pivot, edge);
        }

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
