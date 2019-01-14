using UnityEngine;

namespace Assets.Scripts.Interoplations.Helpers.Conversion
{
    public static class Converter
    {
        #region One variable type to another
        public static Vector2 Vector3ToVector2(Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public static Vector3 Vector2ToVector3(Vector2 vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }

        public static Vector3 MouseClickToWorldSpace()
        {
            Vector3 mousePosition = Input.mousePosition;
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }
        #endregion
    }
}
