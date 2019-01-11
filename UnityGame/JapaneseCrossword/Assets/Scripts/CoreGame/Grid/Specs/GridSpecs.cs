﻿using System;
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
        public float Width;
        public float Height;
        public float StartPositionX;
        public float StartPositionY;

        public void Initialise()
        {
            TileInstance = Object.Instantiate(TilePrefab);
            TileInstance.Initialise();
        }

        public void CalibrateTile(TileSpecs<T> specs)
        {
            var scale = new Vector3(specs.ScaleX, specs.ScaleY);
            TileInstance.Scale(scale);
        }

        public void SetPivotPoint(Vector2 pivotPoint, Edge edgeAnchor)
        {
            var offset = GetOffset(edgeAnchor);
            SetPivotPoint(pivotPoint, offset);
        }

        private Vector2 GetOffset(Edge edge)
        {
            Vector2 offset;
            switch (edge)
            {
                case Edge.Bot:
                    offset = new Vector2(0, 0);
                    break;
                case Edge.Left:
                    offset = new Vector2(-Width, 0);
                    break;
                case Edge.Right:
                    offset = new Vector2(0, 0);
                    break;
                case Edge.Top:
                    offset = new Vector2(0, Height*2);
                    break;
                default:
                    offset = new Vector2(0, 0);
                    break;
            }

            return offset;
        }

        private void SetPivotPoint(Vector2 pivot, Vector2 offset)
        {
            var startPosition =  pivot + offset;
            StartPositionX = startPosition.x;
            StartPositionY = startPosition.y;
        }
    }

    public interface IScalable
    {
        void Scale(Vector2 scale);
    }
}