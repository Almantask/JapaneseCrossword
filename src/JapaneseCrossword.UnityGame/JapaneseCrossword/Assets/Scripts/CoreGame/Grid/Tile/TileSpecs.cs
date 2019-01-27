using Assets.Scripts.CoreGame.Grid.Specs;
using UnityEngine;

namespace Assets.Scripts.CoreGame.Grid.Tile
{
    public class TileSpecs<T> where T:MonoBehaviour, IRenderable, IPhysical, IScalable
    {
        public float ScaleX;
        public float ScaleY;
        public float Width;
        public float Height;

        public TileSpecs(GridSpecs<T> gridSpecs, int cols, int rows)
        {
            Width = gridSpecs.Width / cols;
            Height = gridSpecs.Height / rows;

            ScaleX = Width / gridSpecs.TileInstance.VisualWidth;
            ScaleY = Height / gridSpecs.TileInstance.VisualHeight;
        }
    }
}