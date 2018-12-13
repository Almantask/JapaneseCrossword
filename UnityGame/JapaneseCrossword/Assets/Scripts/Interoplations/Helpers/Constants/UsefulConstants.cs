using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Helpers.Constants
{
    public static class UsefulConstants
    {
        public static Color whiteNoAlfa = new Color(1, 1, 1, 0);
        public static Quaternion zeroRot = Quaternion.Euler(Vector3.zero);
    }
}
