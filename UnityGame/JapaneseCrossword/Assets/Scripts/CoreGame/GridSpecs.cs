using System;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    [Serializable]
    internal class GridSpecs<T> where T:MonoBehaviour, IInitialisable, IRenderable
    {
        public T Tile;
        public float Width;
        public float Height;
        public float StartPositionX;
        public float StartPositionY;

        public void Initialise()
        {
            Tile.Initialise();
        }

        public void CalibrateTile(TileSpecs<T> specs)
        {
            var scale = new Vector3(specs.ScaleX, specs.ScaleY);
            Tile.transform.localScale = scale;
        }
    }
}