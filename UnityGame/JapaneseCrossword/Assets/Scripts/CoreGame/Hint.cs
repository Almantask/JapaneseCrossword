using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CoreGame
{
    [RequireComponent(typeof(TextMesh))]
    public class Hint : MonoBehaviour
    {
        private int _consequitiveColors;
        public int ConsequitiveColors
        {
            set
            {
                _text.text = value.ToString();
                _consequitiveColors = value;
            }
            get { return _consequitiveColors; }
        }

        [SerializeField]
        private TextMesh _text;
    }
}
