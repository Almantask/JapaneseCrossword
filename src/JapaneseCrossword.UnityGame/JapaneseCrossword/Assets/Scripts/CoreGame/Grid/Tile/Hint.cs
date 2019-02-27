using UnityEngine;

namespace Assets.Scripts.CoreGame.Grid.Tile
{
    [RequireComponent(typeof(TextMesh))]
    public class Hint : MonoBehaviour
    {
        private int _consequitiveColors;

        public int ConsequitiveColors
        {
            set
            {
                _text.text = value == 0 ? "" : value.ToString();
                _consequitiveColors = value;
            }
            get { return _consequitiveColors; }
        }

        public int FontSize
        {
            set { _text.fontSize = value; }
            get { return _text.fontSize; }
        }

        [SerializeField]
        private TextMesh _text;
    }
}
