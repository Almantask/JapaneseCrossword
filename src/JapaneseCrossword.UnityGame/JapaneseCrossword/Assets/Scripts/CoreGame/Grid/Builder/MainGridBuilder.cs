using System.Runtime.CompilerServices;
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
        [SerializeField]
        private GameObject _frameFragment;
        [SerializeField]
        private float _frameBorder;

        private GameObject[] _frameWalls;

        public float Height => _gridSpecs.Height;
        public float Width => _gridSpecs.Width;

        private Vector2 _tileDimensions;

        private readonly GridBuilder<GameTile, IMonochrome<ColorChangedEventArgs>> _builder = new GridBuilder<GameTile, IMonochrome<ColorChangedEventArgs>>();

        public PivotPoints CreatePivotPoints(Vector2 size)
        {
            var cellSizeX = _gridSpecs.Width / size.x;
            var cellSizeY = _gridSpecs.Height / size.y;
            _gridSpecs.TilePrefab.Initialise();
            var tileSizeX = cellSizeX * _gridSpecs.TilePrefab.VisualWidth;
            var tileSizeY = cellSizeY * _gridSpecs.TilePrefab.VisualHeight;
            _tileDimensions = new Vector2(tileSizeX, tileSizeY);

            var top = new Vector2(_gridSpecs.StartPositionX, _gridSpecs.StartPositionY + _gridSpecs.Height - tileSizeY / 2); // and height his..
            var left = new Vector2(_gridSpecs.StartPositionX - tileSizeX / 2, _gridSpecs.StartPositionY); // and width his.. TODO
            return new PivotPoints(top, left);
        }

        public void Build(IMonochrome<ColorChangedEventArgs>[,] gridData)
        {
            Clean();
            BuildFrame();
            _builder.Build(gridData, _gridSpecs, transform);
        }

        private void BuildFrame()
        {
            var tmpFragment = Instantiate(_frameFragment, transform);
            var positionNorth = new Vector3(_gridSpecs.StartPositionX - _tileDimensions.x * 0.5f, _gridSpecs.StartPositionY - _tileDimensions.y * 0.5f);
            var northWall = Instantiate(tmpFragment, transform);
            northWall.transform.localScale = new Vector3(Width, _frameBorder, 1);
            northWall.transform.position = positionNorth + Vector3.up * Height + Vector3.right * 0.5f * Width;
            northWall.name = "NorthWall";

            var southWall = Instantiate(tmpFragment, transform);
            southWall.transform.localScale = new Vector3(Width, _frameBorder, 1);
            southWall.transform.position = positionNorth + Vector3.right * 0.5f * Width;
            southWall.name = "SouthWall";

            var eastWall = Instantiate(tmpFragment, transform);
            eastWall.transform.localScale = new Vector3(_frameBorder, Height, 1);
            eastWall.transform.position = positionNorth + Vector3.up * Height * 0.5f;
            eastWall.name = "EastWall";

            var westWall = Instantiate(tmpFragment, transform);
            westWall.transform.localScale = new Vector3(_frameBorder, Height, 1);
            westWall.transform.position = positionNorth + Vector3.right * Width + Vector3.up * Height * 0.5f;
            westWall.name = "WestWall";

            _frameWalls = new[] {westWall, northWall, southWall, eastWall};

            Destroy(tmpFragment);
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
            _builder.CleanUp();
        }

        public void Clean()
        {
            DestroyFrame();
            _builder.CleanUp();
        }

        private void DestroyFrame()
        {
            if (_frameWalls == null) return;
            foreach (var frameWall in _frameWalls)
            {
                if (frameWall != null)
                    Destroy(frameWall);
            }
        }

        public void BindToLogicalTiles(IMonochrome<ColorChangedEventArgs>[,] gameCurrent)
        {
            var cols = gameCurrent.GetLength(0);
            var rows = gameCurrent.GetLength(1);
            for (var col = 0; col < cols; col++)
            {
                for (var row = 0; row < rows; row++)
                {
                    _builder.Tiles[col, row].TileLogical = gameCurrent[col, row];
                }
            }
        }
    }
}