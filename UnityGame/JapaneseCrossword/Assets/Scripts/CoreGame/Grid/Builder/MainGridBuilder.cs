using JapaneseCrossword.Core;
using JapaneseCrossword.Core.Rules;
using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    public class MainGridBuilder:MonoBehaviour, IMainGridBuilder
    {
        public PivotPoints PivotPoints => new PivotPoints(TopLeftPivot, TopRightPivot, BotLeftPivot, BotRightPivot);
        private Vector2 TopLeftPivot => new Vector2(_gridSpecs.StartPositionX, _gridSpecs.StartPositionY);
        private Vector2 TopRightPivot => new Vector2(_gridSpecs.StartPositionX + _gridSpecs.Width, _gridSpecs.StartPositionY);
        private Vector2 BotLeftPivot => new Vector2(_gridSpecs.StartPositionX, _gridSpecs.StartPositionY - _gridSpecs.Height);
        private Vector2 BotRightPivot => new Vector2(_gridSpecs.StartPositionX + _gridSpecs.Width, _gridSpecs.StartPositionY - _gridSpecs.Height);

        [SerializeField]
        private GridSpecsGameTile _gridSpecs;

        private readonly GridBuilder<GameTile, IMonochrome> _builder = new GridBuilder<GameTile, IMonochrome>();

        public void Build(IMonochrome[,] gridData)
        {
            _builder.Build(gridData, _gridSpecs, transform);
        }

        public void Build(int cols, int rows)
        {
            throw new System.NotImplementedException();
        }

        public void Reveal(IMonochrome[,] gridData)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}