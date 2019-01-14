using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    [Serializable]
    public class GridSpecsHintTile : GridSpecs<HintTile>
    {
        public bool IsVertical { set; get; }

        internal void SetPivotPoint(Vector2 pivot)
        {
            StartPositionX = pivot.x;
            StartPositionY = pivot.y;
        }

        public override void Initialise()
        {
            base.Initialise();
            AdjustPivot();
        }

        public void AdjustPivot()
        {
            var offset = GetOffset();
            AdjustPivot(offset);
        }

        private Vector2 GetOffset()
        {
            Vector2 offset;
           if (IsVertical)
           {
               var tileHeight = TileInstance.VisualHeight * Height / Dimensions.y;
                offset = new Vector2(0, tileHeight / 2);
           }
            else
            {
                var tileWidth = TileInstance.VisualWidth *  Width / Dimensions.x;
                offset = new Vector2(-Width + tileWidth / 2, 0);
            }

            return offset;
        }

        private void AdjustPivot(Vector2 offset)
        {
            StartPositionX += offset.x;
            StartPositionY += offset.y;
        }
    }
}
