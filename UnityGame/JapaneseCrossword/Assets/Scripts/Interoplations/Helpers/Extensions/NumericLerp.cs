using UnityEngine;

namespace NumericLerp
{
    public static class NumericLerp
    {
        public static float Lerp(this float value, float valueTo, float fraction)
        {
            float difference = valueTo - value;
            value += difference * fraction;
            Debug.Log(value);
            return value;
        }
    }
}