using System;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    [Serializable]
    internal class GridSpecs
    {
        public GameObject TileObj;
        public float Width;
        public float Height;
        public float StartPositionX;
        public float StartPositionY;

        public Tile Tile { get; private set; }

        public void Initialise()
        {
            var tileComposition = TileObj.GetComponent<ITile>();
            Tile = tileComposition.Initialise();
        }

        public void CalibrateTile(TileSpecs specs)
        {
            var scale = new Vector3(specs.ScaleX, specs.ScaleY);
            TileObj.transform.localScale = scale;
        }
    }
}