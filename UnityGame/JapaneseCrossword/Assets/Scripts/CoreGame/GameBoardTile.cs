using JapaneseCrossword.Core.Rules;
using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    /// <summary>
    /// Needs to have a border on top level and a nested base for color.
    /// </summary>
    public class GameBoardTile : MonoBehaviour, IMonochrome, ITile
    {
        [SerializeField]
        private Tile _tile;

        public void InvertColor()
        {
            IsFilled = !IsFilled;
            _tile.Color = IsFilled ? Color.black : Color.white;
        }

        public bool IsFilled { get; private set; }

        void OnMouseDown()
        {
            InvertColor();
        }

        public Tile Initialise()
        {
            _tile.Initialise();
            return _tile;
        }

        public void SetProperties(object param, bool isLoad = false)
        {
            if (!isLoad) return;
            IMonochrome monochrome = (IMonochrome) param;
            _tile.Color = monochrome.IsFilled ? Color.black : Color.white;
            IsFilled = true;
        }
    }
}
