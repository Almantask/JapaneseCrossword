using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CoreGame
{
    public class PivotPoints
    {
        public Vector2 Top { get; }
        public Vector2 Left { get; }

        public PivotPoints(Vector2 top, Vector2 left)
        {
            Top = top;
            Left = left;
        }
    }
}
