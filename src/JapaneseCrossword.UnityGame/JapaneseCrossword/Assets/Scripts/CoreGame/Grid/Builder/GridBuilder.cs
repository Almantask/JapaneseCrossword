using Assets.Scripts.CoreGame.Grid.Specs;
using Assets.Scripts.CoreGame.Grid.Tile;
using UnityEngine;

namespace Assets.Scripts.CoreGame.Grid.Builder
{
    internal class GridBuilder<T, G> where T: MonoBehaviour, IPhysical, IRenderable, IScalable
    {
        private GridSpecs<T> _gridSpecs;
        protected TileSpecs<T> TileSpecs;

        public float TileWidth => TileSpecs.Width;
        public float TileHeight => TileSpecs.Height;

        public T[,] Tiles { get; private set; }

        private GameObject[] _physicalTiles;

        public void CleanUp()
        {
            if (_physicalTiles == null) return;

            foreach (var physicalTile in _physicalTiles)
            {
                Object.Destroy(physicalTile);
            }

            _physicalTiles = null;
        }

        public void Build(G[,] gridData, GridSpecs<T> gridSpecs, Transform parent)
        {
            CleanUp();
            var cols = gridData.GetLength(0);
            var rows = gridData.GetLength(1);

            _physicalTiles = new GameObject[cols*rows];
            Tiles = new T[cols, rows];

            LoadSpecs(gridSpecs, cols, rows);

            for (var col = 0; col < cols; col++)
            {
                for (var row = 0; row < rows; row++)
                {
                    var tileObj = Object.Instantiate(gridSpecs.TileInstance, parent).gameObject;

                    var tileIndex = col * rows + row;
                    _physicalTiles[tileIndex] = tileObj;

                    Tiles[col, row] = tileObj.GetComponent<T>();
                    tileObj.name = $"TileObj [{col},{row}]";
                    RepositionTile(col, row, tileObj.transform);

                    var tile = tileObj.GetComponent<IPhysical>();
                    tile.BindToLogical(gridData[col, row]);
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
            const float tileOffsetZ = 1;

            var position = new Vector3(_gridSpecs.StartPositionX + offsetX, _gridSpecs.StartPositionY + offsetY, tileOffsetZ);
            tile.position = position;
        }

    }
}
