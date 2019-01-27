using System;
using Assets.Scripts.CoreGame.Grid.Specs;
using JapaneseCrossword.Core.Rules;
using UnityEngine;

namespace Assets.Scripts.CoreGame.Grid.Tile
{
    /// <summary>
    /// Needs to have a border on top level and a nested base for color.
    /// </summary>
    [RequireComponent(typeof(BoxCollider2D))]
    [Serializable]
    public class GameTile : MonoBehaviour, IMonochrome<ColorChangedEventArgs>, IPhysical, IRenderable, IScalable
    {
        [SerializeField]
        private Tile _tilePhysical;

        private IMonochrome<ColorChangedEventArgs> _tileLogical;

        public float VisualHeight => _tilePhysical.VisualHeight;
        public float VisualWidth => _tilePhysical.VisualWidth;
        public bool IsFilled { get; private set; }
        public EventHandler<ColorChangedEventArgs> ColorChanged { get; set; }

        void OnMouseDown()
        {
            InvertColor();
        }

        public void InvertColor()
        {
            IsFilled = !IsFilled;
            _tilePhysical.Color = IsFilled ? Color.black : Color.white;
            _tileLogical?.ColorChanged?.Invoke(_tileLogical, new ColorChangedEventArgs(IsFilled));
        }

        public object Initialise()
        {
            _tilePhysical.Initialise();
            return _tilePhysical;
        }

        public void BindToLogical(object param, bool isLoad = false)
        {
            var monochrome = (IMonochrome<ColorChangedEventArgs>[])param;
            _tileLogical = monochrome[0];
            if (!isLoad) return;
            _tilePhysical.Color = monochrome[1].IsFilled ? Color.black : Color.white;
            IsFilled = false;
        }

        public void Scale(Vector2 scale)
        {
            _tilePhysical.transform.localScale = scale;
            var collider = GetComponent<BoxCollider2D>();
            collider.size = scale;
        }
    }
}
