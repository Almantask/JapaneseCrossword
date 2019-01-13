using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.CoreGame
{
    [Serializable]
    public class GridSpecs<T> where T:MonoBehaviour, IInitialisable, IRenderable, IScalable
    {
        public T TilePrefab;
        public T TileInstance { private set; get; }
        public Vector2 Dimensions { get; set; }

        public float Width;
        public float Height;
        public float StartPositionX;
        public float StartPositionY;

        public virtual void Initialise()
        {
            TileInstance = Object.Instantiate(TilePrefab);
            TileInstance.Initialise();
        }

        public void CalibrateTile(TileSpecs<T> specs)
        {
            var scale = new Vector3(specs.ScaleX, specs.ScaleY);
            TileInstance.Scale(scale);
        }

    }

    public interface IScalable
    {
        void Scale(Vector2 scale);
    }
}