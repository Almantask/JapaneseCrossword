using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    public class HintTile : MonoBehaviour, IInitialisable, IRenderable, IScalable
    {
        public float VisualHeight => _tile.VisualHeight;
        public float VisualWidth => _tile.VisualWidth;

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
            _tile.Initialise();
            return _tile;
        }

        public void Scale(Vector2 scale)
        {
            
        }
    }
}
