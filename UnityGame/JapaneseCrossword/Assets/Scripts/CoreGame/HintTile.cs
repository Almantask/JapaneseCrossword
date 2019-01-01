using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    public class HintTile : MonoBehaviour, ITile
    {
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

        Tile ITile.Initialise()
        {
            throw new System.NotImplementedException();
        }
    }
}
