using JapaneseCrossword.Core;
using JapaneseCrossword.Core.Rules;
using UnityEngine;

public class MainGridBuilder:MonoBehaviour, IMainGridBuilder
{
    public GameBoardTile GameBoardTile;
    public Camera Camera;

    public float TileWidth;
    public float TileHeight;

    public float InitialTilePositionX;
    public float InitialTilePositionY;

    private float _tileScaleX;
    private float _tileScaleY;

    //private readonly float tileWidthOffset;
    //private readonly float tileHeightOffset;

    void Awake()
    {
        _tileScaleX = TileWidth / GameBoardTile.VisualWidth;
        _tileScaleY = TileHeight / GameBoardTile.VisualHeight;
        GameBoardTile.transform.localScale = new Vector3(_tileScaleX, _tileScaleY);
    }

    public void Build(IMonochrome[,] gridData)
    {
        for (var col = 0; col < gridData.GetLength(0); col++)
        {
            for (var row = 0; row < gridData.GetLength(1); row++)
            {
                var tileObj = Instantiate(GameBoardTile, transform).gameObject;
                tileObj.name = $"Tile [{col},{row}]";
                RepositionTile(col, row, tileObj.transform);

                var tile = tileObj.GetComponent<GameBoardTile>();
                if(gridData[col, row].IsFilled)
                    tile.InvertColor();
            }
        }
    }

    private void RepositionTile(int col, int row, Transform tile)
    {
        var offsetX = col * TileWidth;
        var offsetY = row * TileHeight;
        
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