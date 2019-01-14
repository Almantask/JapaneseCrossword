using JapaneseCrossword.Core.Rules;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace Assets.Scripts.CoreGame
{
    internal class GridBuilder<T, G> where T: MonoBehaviour, IInitialisable, IRenderable, IScalable
    {
        private GridSpecs<T> _gridSpecs;
        protected TileSpecs<T> TileSpecs;

        public float TileWidth => TileSpecs.Width;
        public float TileHeight => TileSpecs.Height;

        public void Build(G[,] gridData, GridSpecs<T> gridSpecs, Transform parent)
        {
            var cols = gridData.GetLength(0);
            var rows = gridData.GetLength(1);

            LoadSpecs(gridSpecs, cols, rows);

            for (var col = 0; col < cols; col++)
            {
                for (var row = 0; row < rows; row++)
                {
                    var tileObj = Object.Instantiate(gridSpecs.TileInstance, parent).gameObject;
                    tileObj.name = $"TileObj [{col},{row}]";
                    RepositionTile(col, row, tileObj.transform);

                    var tile = tileObj.GetComponent<IInitialisable>();
                    tile.SetProperties(gridData[col, row]);
                }
            }

            Object.Destroy(gridSpecs.TileInstance.gameObject);
        }

        public void LoadSpecs(GridSpecs<T> gridSpecs, int cols, int rows)
        {
            gridSpecs.Dimensions = new Vector2(cols, rows);
            gridSpecs.Initialise();
            TileSpecs = new TileSpecs<T>(gridSpecs, cols, rows);
            gridSpecs.CalibrateTile(TileSpecs);
            // Because I cannot serialise GridSpecs<T>
            _gridSpecs = gridSpecs;
        }

        private float CalculateTileEdgeSize()
        {
            return 0;
        }

        private void RepositionTile(int col, int row, Transform tile)
        {
            var offsetX = col * TileSpecs.Width;
            var offsetY = row * TileSpecs.Height;

            var position = new Vector2(_gridSpecs.StartPositionX + offsetX, _gridSpecs.StartPositionY + offsetY);
            tile.position = position;
        }
    }
}
