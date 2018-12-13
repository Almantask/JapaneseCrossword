using UnityEngine;
using Assets.Scripts.Helpers.Conversion;


namespace Assets.Scripts.Helpers.Extensions.Vector2Extensions
{
    public static class Vector2Extension
    {
        #region Vector2 functionality not included in Vector3
        public static Quaternion Vector2LookAtTouch(this Vector2 position, bool away)
        {

            Vector3 diff = Camera.main.ScreenToWorldPoint(Converter.Vector2ToVector3(Input.touches[0].position)) - Converter.Vector2ToVector3(position);
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            if (away)
                return Quaternion.Euler(0f, 0f, rot_z + 180);
            else
                return Quaternion.Euler(0f, 0f, rot_z - 180);
        }
        #endregion
    }
}
