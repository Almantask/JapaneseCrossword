using JapaneseCrossword.Core;
using JapaneseCrossword.Core.Rules;
using UnityEngine;

public class MainGridBuilder:MonoBehaviour, IMainGridBuilder
{
    [SerializeField]
    private GameBoardTile _gameBoardTile;
    [SerializeField]
    private float _gridWidth;
    [SerializeField]
    private float _gridHeight;
    [SerializeField]
    private float InitialTilePositionX;
    [SerializeField]
    private float InitialTilePositionY;

    private float _tileWidth;
    private float _tileHeight;
    private float _tileScaleX;
    private float _tileScaleY;

    public void Build(IMonochrome[,] gridData)
    {

        for (var col = 0; col < gridData.GetLength(0); col++)
        {
            for (var row = 0; row < gridData.GetLength(1); row++)
            {
                var tileObj = Instantiate(_gameBoardTile, transform).gameObject;
                tileObj.name = $"Tile [{col},{row}]";
                RepositionTile(col, row, tileObj.transform);

                var tile = tileObj.GetComponent<GameBoardTile>();
                if(gridData[col, row].IsFilled)
                    tile.InvertColor();
            }
        }
    }

    private void AdjutTileScale()
    {
        _tileScaleX = _tileWidth / _gameBoardTile.VisualWidth;
        _tileScaleY = _tileHeight / _gameBoardTile.VisualHeight;
        _gameBoardTile.transform.localScale = new Vector3(_tileScaleX, _tileScaleY);
    }

    private void RepositionTile(int col, int row, Transform tile)
    {
        var offsetX = col * _tileWidth;
        var offsetY = row * _tileHeight;
        
        var position = new Vector2(InitialTilePositionX + offsetX, InitialTilePositionY + offsetY);
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