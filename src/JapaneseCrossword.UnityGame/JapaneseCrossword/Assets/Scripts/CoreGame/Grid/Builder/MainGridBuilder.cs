using Assets.Scripts.CoreGame.Grid.Specs;
using Assets.Scripts.CoreGame.Grid.Tile;
using JapaneseCrossword.Core;
using JapaneseCrossword.Core.Rules;
using UnityEngine;

namespace Assets.Scripts.CoreGame.Grid.Builder
{
    public class MainGridBuilder:MonoBehaviour, IMainGridBuilder
    {
        [SerializeField]
        private GridSpecsGameTile _gridSpecs;

        public float Height => _gridSpecs.Height;
        public float Width => _gridSpecs.Width;

        private readonly GridBuilder<GameTile, IMonochrome<ColorChangedEventArgs>> _builder = new GridBuilder<GameTile, IMonochrome<ColorChangedEventArgs>>();

        public PivotPoints CreatePivotPoints(Vector2 size)
        {
            var cellSizeX = _gridSpecs.Width / size.x;
            var cellSizeY = _gridSpecs.Height / size.y;
            _gridSpecs.TilePrefab.Initialise();
            var tileSizeX = cellSizeX * _gridSpecs.TilePrefab.VisualWidth;
            var tileSizeY = cellSizeY * _gridSpecs.TilePrefab.VisualHeight;

            var top = new Vector2(_gridSpecs.StartPositionX, _gridSpecs.StartPositionY + _gridSpecs.Height - tileSizeY / 2); // and height his..
            var left = new Vector2(_gridSpecs.StartPositionX - tileSizeX / 2, _gridSpecs.StartPositionY); // and width his.. TODO
            return new PivotPoints(top, left);
        }

        public void Build(IMonochrome<ColorChangedEventArgs>[,] gridData)
        {
            _builder.Build(gridData, _gridSpecs, transform);
        }

        public void Build(int cols, int rows)
        {
            throw new System.NotImplementedException();
        }

        public void Reveal(IMonochrome<ColorChangedEventArgs>[,] gridData)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public void Clean()
        {
            throw new System.NotImplementedException();
        }
    }
}