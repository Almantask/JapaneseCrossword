using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    internal class TileSpecs
    {
        public float ScaleX;
        public float ScaleY;
        public float Width;
        public float Height;

        public TileSpecs(GridSpecs gridSpecs, int cols, int rows)
        {
            Width = gridSpecs.Width / cols;
            Height = gridSpecs.Height / rows;

            ScaleX = Width / gridSpecs.Tile.VisualWidth;
            ScaleY = Height / gridSpecs.Tile.VisualHeight;
        }
    }
}