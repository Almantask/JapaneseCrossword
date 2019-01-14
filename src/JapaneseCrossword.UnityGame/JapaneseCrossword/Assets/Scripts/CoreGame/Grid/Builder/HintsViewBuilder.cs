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

        public float Width
        {
            set { _gridSpecs.Width = value; }
        }

        public float Height
        {
            set { _gridSpecs.Height = value; }
        }

        private readonly GridBuilder<HintTile, int> _builder = new GridBuilder<HintTile, int>();

        public void SetPivot(Vector2 pivot)
        {
            _gridSpecs.SetPivotPoint(pivot);
        }

        public bool IsVertical => _isVertical;

        public void Build(int[,] gridData)
        {
            _gridSpecs.IsVertical = _isVertical;
            _builder.Build(gridData, _gridSpecs, transform);
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        

    }
}
