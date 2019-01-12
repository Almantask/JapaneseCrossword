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

        public void SetPivot(Vector2 pivot, Edge edge, int cols, int rows)
        {
            _gridSpecs.SetPivotPoint(pivot, edge, cols, rows);
        }

        public bool IsVertical => _isVertical;

        public void Build(int[,] gridData)
        {
            _builder.Build(gridData, _gridSpecs, transform);
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

    }
}
