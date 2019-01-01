using JapaneseCrossword.Core;
using JapaneseCrossword.Core.Rules;
using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    public class MainGridBuilder:MonoBehaviour, IMainGridBuilder
    {
        public Vector2 TopLeftPivot => new Vector2(_gridSpecs.StartPositionX, _gridSpecs.StartPositionY);
        public Vector2 TopRightPivot => new Vector2(_gridSpecs.StartPositionX + _gridSpecs.Width, _gridSpecs.StartPositionY);
        public Vector2 BotLeftPivot => new Vector2(_gridSpecs.StartPositionX, _gridSpecs.StartPositionY + _gridSpecs.Height);
        public Vector2 BotRightPivot => new Vector2(_gridSpecs.StartPositionX + _gridSpecs.Width, _gridSpecs.StartPositionY + _gridSpecs.Height);

        [SerializeField]
        private GridSpecs _gridSpecs;
        private TileSpecs _tileSpecs;

        public void Build(IMonochrome[,] gridData)
        {
            var cols = gridData.GetLength(0);
            var rows = gridData.GetLength(1);

            InitialiseSpecs(cols, rows);

            for (var col = 0; col < cols; col++)
            {
                for (var row = 0; row < rows; row++)
                {
                    var tileObj = Instantiate(_gridSpecs.TileObj, transform).gameObject;
                    tileObj.name = $"TileObj [{col},{row}]";
                    RepositionTile(col, row, tileObj.transform);

                    var tile = tileObj.GetComponent<ITile>();
                    tile.SetProperties(gridData[col, row]);
                }
            }
        }

        private void InitialiseSpecs(int cols, int rows)
        {
            _gridSpecs.Initialise();
            _tileSpecs = new TileSpecs(_gridSpecs, cols, rows);
            _gridSpecs.CalibrateTile(_tileSpecs);
        }

        private float CalculateTileEdgeSize()
        {
            return 0;
        }

        private void RepositionTile(int col, int row, Transform tile)
        {
            var offsetX = col * _tileSpecs.Width;
            var offsetY = row * _tileSpecs.Height;
        
            var position = new Vector2(_gridSpecs.StartPositionX + offsetX, _gridSpecs.StartPositionY + offsetY);
            tile.position = position;
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