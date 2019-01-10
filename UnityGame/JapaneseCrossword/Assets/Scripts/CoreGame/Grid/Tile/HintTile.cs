using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    public class HintTile : MonoBehaviour, IInitialisable, IRenderable, IScalable
    {
        private bool _initialised;

        public float VisualHeight => _tile.VisualHeight;
        public float VisualWidth => _tile.VisualWidth;

        private int _intialHintFontSize;

        public int ConsequitiveColors
        {
            set { _hint.ConsequitiveColors = value; }
            get { return _hint.ConsequitiveColors; }
        }

        [SerializeField]
        private Tile _tile;
        [SerializeField]
        private Hint _hint;

        // TODO: reconsider...
        public Tile Initialise()
        {
            _tile.Initialise();
            return _tile;
        }

        public void SetProperties(object param, bool isLoad = false)
        {
            int number = (int) param;
            ConsequitiveColors = number;
        }

        object IInitialisable.Initialise()
        {
            if (!_initialised)
            {
                _tile.Initialise();
                _intialHintFontSize = _hint.FontSize;
                _initialised = true;
            }

            return _tile;
        }

        public void Scale(Vector2 scale)
        {
            _tile.transform.localScale = scale;

            var fontSizeRatio = scale.x < scale.y ? scale.x : scale.y;
            _hint.FontSize = (int)(_intialHintFontSize * fontSizeRatio);
        }


    }
}
