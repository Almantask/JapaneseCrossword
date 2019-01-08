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
        public Vector2 TopLeft { get; }
        public Vector2 TopRight { get; }
        public Vector2 BotLeft { get; }
        public Vector2 BotRight { get; }

        public PivotPoints(Vector2 topLeft, Vector2 topRight, Vector2 botLeft, Vector2 botRight)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BotLeft = botLeft;
            BotRight = botRight;
        }
    }
}
