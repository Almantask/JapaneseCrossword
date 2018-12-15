using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Helpers.General
{
    /// <summary>
    /// Converters, UI helpers, 2d functionality not included in 3d, array expanding functions and other helpful functions
    /// </summary>
    public static class GeneralHelper
    {

        #region other
        /// <summary>
        /// Checks wheteher the given point is in the main camera's range
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool IsPointInCameraRangeY(Vector3 point)
        {
            Camera mainCamera = Camera.main;
            Vector3 cameraPosition = mainCamera.transform.position;
            float cameraSize = mainCamera.orthographicSize;
            float boundYUpper = cameraPosition.y + cameraSize + 2; // 2 is for task width
            float boundYLower = cameraPosition.y - cameraSize - 2;
            if (point.y < boundYUpper && point.y > boundYLower)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Is game pasued
        /// </summary>
        /// <returns></returns>
        public static bool IsPaused()
        {
            return Time.timeScale == 0;
        }

        /// <summary>
        /// Nuber with suffix
        /// </summary>
        /// <param name="number"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static string NumberWithSuffix(ulong number, ushort precision = 0)
        {
            char suffix;
            ulong divider;
            if (number >= 1000000000000)
            {
                divider = 1000000000000;
                suffix = 'T';
            }
            else if (number >= 1000000000)
            {
                divider = 1000000000;
                suffix = 'B';
            }
            else if (number >= 1000000)
            {
                divider = 1000000;
                suffix = 'M';
            }
            else if (number >= 1000)
            {
                divider = 1000;
                suffix = 'K';
            }
            else
            {
                divider = 1;
                suffix = ' ';
            }
            if (precision == 0)
            {
                number /= divider;
                if (suffix.CompareTo(' ') == 0)
                    return number.ToString();
                else
                    return string.Concat(number.ToString() + suffix);
            }
            else
            {
                if (suffix.CompareTo(' ') == 0)
                {
                    number /= divider;
                    return number.ToString();
                }
                else
                {
                    decimal result = (decimal)number / divider;
                    decimal result2 = Math.Round(result, precision);
                    decimal result3 = Math.Round(result);
                    if (result2.CompareTo(result3) == 0)
                    {
                        number /= divider;
                        return string.Concat(number.ToString() + suffix);
                    }
                    else
                        return string.Concat(result2.ToString(), suffix);
                }
            }
        }

        /// <summary>
        /// Custom power function for double
        /// </summary>
        /// <param name="num"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static float MyPowf(float num, int exp)
        {
            float result = 1.0f;
            while (exp > 0)
            {
                if (exp % 2 == 1)
                    result *= num;
                exp >>= 1;
                num *= num;
            }
            return result;
        }

        /// <summary>
        /// Destroys GameObject after some time
        /// </summary>
        /// <param name="toDestroy"> Object to destroy</param>
        /// <param name="delay"> Tiem it wait till destruction</param>
        /// <returns></returns>
        public static IEnumerator DestroyAfterTime(GameObject toDestroy, float delay)
        {
            if (delay > 0)
                yield return new WaitForSeconds(delay);
            UnityEngine.Object.Destroy(toDestroy);
        }

        public static IEnumerator DestroyAfterTime(GameObject toDestroy, float secondsDelay1, float secondsDelay2, bool isWithObjectMoveOB)
        {
            if (secondsDelay1 + secondsDelay2 > 0)
            {
                yield return new WaitForSeconds(secondsDelay1);
                if (isWithObjectMoveOB)
                {
                    toDestroy.transform.Translate(Vector2.down * 20);
                }
                yield return new WaitForSeconds(secondsDelay2);
                UnityEngine.Object.Destroy(toDestroy.gameObject);
            }
            else
            {
                UnityEngine.Object.Destroy(toDestroy.gameObject);
            }
        }

        /// <summary>
        /// Returns a non shallow copy of a list
        /// </summary>
        /// <returns></returns>
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        /// <summary>
        /// Move a gameobject from one rendered layer to another, thus changing its position along with its children (recursively)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="prevRendererPosition"></param>
        /// <param name="nextRendererPosition"></param>
        /// <param name="newLayer"></param>
        /// <param name="newZ">New z, if 0, then use starting z</param>
        public static void ObjectRenderingLayerChange(GameObject obj, Vector3 prevRendererPosition, Vector3 nextRendererPosition, int newLayer, float newZ = -1000)
        {
            SetLayerRecursively(obj, newLayer);
            Vector3 offsetFromCamera = obj.transform.position - prevRendererPosition;
            if (newZ == -1000)
                newZ = obj.transform.position.z;
            obj.transform.position = new Vector3(nextRendererPosition.x, nextRendererPosition.y, 0) + new Vector3(offsetFromCamera.x, offsetFromCamera.y, newZ);
        }


        /// <summary>
        /// Changes the rendering layers of obj and all recursive children
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="newLayer"></param>
        public static void SetLayerRecursively(GameObject obj, int newLayer)
        {
            if (null == obj)
            {
                return;
            }

            obj.layer = newLayer;

            foreach (Transform child in obj.transform)
            {
                if (null == child)
                {
                    continue;
                }
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }
        #endregion




    }
}
