using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    public class Tile:MonoBehaviour
    {
        public float VisualWidth { get; private set; }
        public float VisualHeight { get; private set; }

        public Color Color
        {
            set { _renderer.color = value; }
            get { return _renderer.color; } 
        }

        private SpriteRenderer _renderer;
        private bool _isInitialised;

        private void Awake()
        {
            Initialise();
        }

        public void Initialise()
        {
            if (_isInitialised) return;
            SetRenderer();
            var bounds = _renderer.bounds;
            VisualWidth = bounds.size.x;
            VisualHeight = bounds.size.y;
            _isInitialised = true;
        }

        private void SetRenderer()
        {
            var borderHolder = transform.GetChild(0);
            var baseHolder = borderHolder.GetChild(0);
            _renderer = baseHolder.GetComponent<SpriteRenderer>();
        }
    }
}