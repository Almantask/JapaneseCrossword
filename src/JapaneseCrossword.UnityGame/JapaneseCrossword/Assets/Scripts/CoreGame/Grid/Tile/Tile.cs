using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    public class Tile:MonoBehaviour
    {
        public float VisualWidth => _bounds.size.x;//{ get; private set; }
        public float VisualHeight => _bounds.size.y; //{ get; private set; }

        public Color Color
        {
            set { _rendererColor.color = value; }
            get { return _rendererColor.color; } 
        }

        private SpriteRenderer _rendererColor;
        private SpriteRenderer _rendererFrame;
        private bool _isInitialised;
        private Bounds _bounds;

        void Awake()
        {
            Initialise();
        }

        public void Initialise()
        {
            if (_isInitialised) return;
            SetRenderer();
            _bounds = _rendererFrame.bounds;
            //VisualWidth = bounds.size.x;
            //VisualHeight = bounds.size.y;
            _isInitialised = true;
        }

        private void SetRenderer()
        {
            var borderHolder = transform.GetChild(0);
            var baseHolder = borderHolder.GetChild(0);

            _rendererColor = baseHolder.GetComponent<SpriteRenderer>();
            _rendererFrame = borderHolder.GetComponent<SpriteRenderer>();
        }
    }
}