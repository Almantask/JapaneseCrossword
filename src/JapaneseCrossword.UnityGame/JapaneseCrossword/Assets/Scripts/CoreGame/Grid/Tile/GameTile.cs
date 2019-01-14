using System;
using JapaneseCrossword.Core.Rules;
using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    /// <summary>
    /// Needs to have a border on top level and a nested base for color.
    /// </summary>
    [RequireComponent(typeof(BoxCollider2D))]
    [Serializable]
    public class GameTile : MonoBehaviour, IMonochrome, IInitialisable, IRenderable, IScalable
    {
        [SerializeField]
        private Tile _tile;

        public float VisualHeight => _tile.VisualHeight;
        public float VisualWidth => _tile.VisualWidth;
        public bool IsFilled { get; private set; }

        public void InvertColor()
        {
            IsFilled = !IsFilled;
            _tile.Color = IsFilled ? Color.black : Color.white;
        }

        void OnMouseDown()
        {
            InvertColor();
        }

        public object Initialise()
        {
            _tile.Initialise();
            return _tile;
        }

        public void SetProperties(object param, bool isLoad = false)
        {
            if (!isLoad) return;
            IMonochrome monochrome = (IMonochrome) param;
            _tile.Color = monochrome.IsFilled ? Color.black : Color.white;
            IsFilled = false;
        }

        public void Scale(Vector2 scale)
        {
            _tile.transform.localScale = scale;
            var collider = GetComponent<BoxCollider2D>();
            collider.size = scale;
        }
    }
}
