using System.Collections;
using Assets.Scripts.Interoplations.Helpers.General;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interoplations.Helpers.Animation
{
    /// <summary>
    /// InterpolateEs between any of the following variables: text.color, material.color, textMesh.color, transform(position, location,scale) or numeric values
    /// Also some minimalistic effects, such as pulsating using the mentioned functions
    /// </summary>
    public static class Interpolator
    {
        #region Interpolator Helpers
        /// <summary>
        /// Interpolates value from current to 1
        /// </summary>
        /// <param name="value"> Value to Interpolate</param>
        /// <param name="speed"> Interpolation speed</param>
        /// <param name="isUnscaledTime"> Is unpaused</param>
        /// <returns> Value closer to 1</returns>
        public static float To1(this float value, float speed, bool isUnscaledTime, Easings.Function interpolator, out float easedResult)
        {
            if (!isUnscaledTime)
                value += Time.deltaTime * speed;
            else
                value += Time.unscaledDeltaTime * speed;
            if (value > 1)
                value = 1;
            easedResult = interpolator(value);
            return value;
        }

        /// <summary>
        /// Interpolates value from current to 1
        /// </summary>
        /// <param name="value"> Value to Interpolate</param>
        /// <param name="speed"> Interpolation speed</param>
        /// <param name="isUnscaledTime"> Is unpaused</param>
        /// <returns> Value closer to 1</returns>
        public static float To1(this float value, float speed, bool isUnscaledTime)
        {
            if (!isUnscaledTime)
                value += Time.deltaTime * speed;
            else
                value += Time.unscaledDeltaTime * speed;
            if (value > 1)
                value = 1;
            return value;
        }

        /// <summary>
        /// Delay for some time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static IEnumerator DelayE(float time)
        {
            if (GeneralHelper.IsPaused())
                yield return new WaitForSecondsRealtime(time);
            else
                yield return new WaitForSeconds(time);
        }
        #endregion

        #region Point Interpolators
        /// <summary>
        /// Interpolates between 2 points 3D
        /// </summary>
        /// <param name="to"> Destination point</param>
        /// <param name="target"> Target to be interpolated</param>
        /// <param name="speed"> /speed is the time it takes to travel</param>
        public static IEnumerator InterpolatePointE(Transform target, Vector3 to, float time, Easings.Functions interpolationFunction = Easings.Functions.Linear)
        {
            Easings.Function interpolator = Easings.GetInterpolator(interpolationFunction);
            float fraction = 0;
            float speed = 1 / time;
            bool isUnscaledTime = GeneralHelper.IsPaused();
            Vector3 from = target.position;
            float easedValue;
            while (fraction < 1)
            {
                fraction.To1(speed, isUnscaledTime, interpolator, out easedValue);
                target.transform.position = Vector3.Lerp(from, to, easedValue);
                yield return null;
            }
        }

        /// <summary>
        /// Interpolates between 2 points 2D
        /// </summary>
        /// <param name="to"> Destination point</param>
        /// <param name="target"> Target to be interpolated</param>
        /// <param name="speed"> /speed is the time it takes to travel</param>
        public static IEnumerator InterpolatePointE(Transform target, Vector2 to, float time, Easings.Functions interpolationFunction = Easings.Functions.Linear)
        {
            Easings.Function interpolator = Easings.GetInterpolator(interpolationFunction);
            float fraction = 0;
            float speed = 1 / time;
            bool isUnscaledTime = GeneralHelper.IsPaused();
            Vector2 from = target.position;
            float easedValue;
            while (fraction < 1)
            {
                fraction.To1(speed, isUnscaledTime, interpolator, out easedValue);
                target.transform.position = Vector2.Lerp(from, to, easedValue);
                yield return null;
            }
        }
        #endregion

        #region Color Interpolators
        /// <summary>
        /// Changes targets color dynamically from one to another
        /// </summary>
        /// <param name="target"> Sprite renderer of a target which will have it's color changed</param>
        /// <param name="colorTo"> Color to which the previous one will be changed</param>
        /// <returns></returns>
        public static IEnumerator InterpolateColorE(SpriteRenderer target, Color colorTo, float time = 1, Easings.Functions interpolationFunction = Easings.Functions.Linear)
        {
            Color colorFrom = target.color;
            Color newColor;
            Easings.Function interpolator = Easings.GetInterpolator(interpolationFunction);
            float fraction = 0;
            float speed = 1 / time;
            bool isUnscaledTime = GeneralHelper.IsPaused();
            float easedValue;
            while (fraction < 1)
            {
                fraction.To1(speed, isUnscaledTime, interpolator, out easedValue);
                newColor = Color.Lerp(colorFrom, colorTo, easedValue);
                target.color = newColor;
                yield return null;
            }
        }

        /// <summary>
        /// Changes targets color dynamically from one to another
        /// </summary>
        /// <param name="target"> Sprite renderer of a target which will have it's color changed</param>
        /// <param name="colorTo"> Color to which the previous one will be changed</param>
        /// <returns></returns>
        public static IEnumerator InterpolateColorE(Material target, Color colorTo, float time = 1, Easings.Functions interpolationFunction = Easings.Functions.Linear)
        {
            Color colorFrom = target.color;
            Color newColor;
            Easings.Function interpolator = Easings.GetInterpolator(interpolationFunction);
            float fraction = 0;
            float speed = 1 / time;
            bool isUnscaledTime = GeneralHelper.IsPaused();
            float easedValue;
            while (fraction < 1)
            {
                fraction.To1(speed, isUnscaledTime, interpolator, out easedValue);
                newColor = Color.Lerp(colorFrom, colorTo, easedValue);
                target.color = newColor;
                yield return null;
            }
        }

        /// <summary>
        /// Interpolates image color from one to another
        /// </summary>
        /// <param name="target">Target image</param>
        /// <param name="colorTo"> Color to interpolate to</param>
        /// <param name="time"> Interpolation time</param>
        /// <param name="interpolationFunction"> Interpolating function</param>
        /// <returns></returns>
        public static IEnumerator InterpolateColorE(Image target, Color colorTo, float time, Easings.Functions interpolationFunction = Easings.Functions.SineEaseIn)
        {
            Color colorFrom = target.color;
            Color newColor;
            Easings.Function interpolator = Easings.GetInterpolator(interpolationFunction);
            float fraction = 0;
            float speed = 1 / time;
            float easedValue;
            bool isUnscaledTime = GeneralHelper.IsPaused();
            while (fraction < 1)
            {
                fraction.To1(speed, isUnscaledTime, interpolator, out easedValue);
                newColor = Color.Lerp(colorFrom, colorTo, easedValue);
                target.color = newColor;
                yield return null;
            }
        }

        /// <summary>
        /// Interpolates TextMesh color from one to another
        /// </summary>
        /// <param name="target">Target image</param>
        /// <param name="colorTo"> Color to interpolate to</param>
        /// <param name="time"> Interpolation time</param>
        /// <param name="interpolationFunction"> Interpolating function</param>
        /// <returns></returns>
        public static IEnumerator InterpolateColorE(TextMesh target, Color colorTo, float time, Easings.Functions interpolationFunction = Easings.Functions.SineEaseIn)
        {
            Easings.Function interpolator = Easings.GetInterpolator(interpolationFunction);
            float fraction = 0;
            float speed = 1 / time;
            float easedValue;
            Color colorFrom = target.color;
            Color newColor;
            bool isUnscaledTime = GeneralHelper.IsPaused();
            while (fraction < 1)
            {
                fraction.To1(speed, isUnscaledTime, interpolator, out easedValue);
                newColor = Color.Lerp(colorFrom, colorTo, easedValue);
                target.color = newColor;
                yield return null;
            }
        }

        /// <summary>
        /// Interpolates Text color from one to another
        /// </summary>
        /// <param name="target">Target image</param>
        /// <param name="colorTo"> Color to interpolate to</param>
        /// <param name="time"> Interpolation time</param>
        /// <param name="interpolationFunction"> Interpolating function</param>
        /// <returns></returns>
        public static IEnumerator InterpolateColorE(Text target, Color colorTo, float time, Easings.Functions interpolationFunction = Easings.Functions.SineEaseIn, float delay = 0)
        {
            Color colorFrom = target.color;
            Color newColor;
            Easings.Function interpolator = Easings.GetInterpolator(interpolationFunction);
            float fraction = 0;
            float speed = 1 / time;
            float easedValue;
            bool isUnscaledTime = GeneralHelper.IsPaused();
            while (fraction < 1)
            {
                fraction.To1(speed, isUnscaledTime, interpolator, out easedValue);
                newColor = Color.Lerp(colorFrom, colorTo, easedValue);
                target.color = newColor;
                yield return null;
            }
        }
        #endregion

        #region Scale Interpolators
        /// <summary>
        /// Moves from one size to another dynamically
        /// </summary>
        /// <param name="transform"> Transform obj to be scaled</param>
        /// <param name="scaleTo"> Scale to</param>
        /// <param name="time"> Time it takes to scale</param>
        /// <param name="interpolationFunction"> Scaling interpolator</param>
        /// <param name="isUnscaledTime"> Is not paused</param>
        /// <returns></returns>
        public static IEnumerator InterpolateScaleE(Transform transform, Vector3 scaleTo, float time = 1, Easings.Functions interpolationFunction = Easings.Functions.Linear)
        {
            Vector3 currntScale = transform.localScale;
            Easings.Function interpolator = Easings.GetInterpolator(interpolationFunction);
            float fraction = 0;
            float speed = 1 / time;
            bool isUnscaledTime = GeneralHelper.IsPaused();
            float easedValue;
            while (fraction < 1)
            {
                fraction.To1(speed, isUnscaledTime, interpolator, out easedValue);
                Vector3 newScale = Vector3.Lerp(currntScale, scaleTo, easedValue);
                transform.localScale = newScale;
                yield return null;
            }
        }

        /// <summary>
        /// Moves from one size to another dynamically
        /// </summary>
        /// <param name="transform"> Transform obj to be scaled</param>
        /// <param name="scaleTo"> Scale to</param>
        /// <param name="time"> Time it takes to scale</param>
        /// <param name="interpolationFunction"> Scaling interpolator</param>
        /// <param name="isUnscaledTime"> Is not paused</param>
        /// <returns></returns>
        public static IEnumerator InterpolateScaleE(RectTransform rectTransform, Vector2 scaleTo, float time = 1, Easings.Functions interpolationFunction = Easings.Functions.Linear)
        {
            //rectTransform.position = new Vector3(0, 0, 0);
            Vector2 currntScale = rectTransform.sizeDelta;
            Easings.Function interpolator = Easings.GetInterpolator(interpolationFunction);
            float fraction = 0;
            float speed = 1 / time;
            bool isUnscaledTime = GeneralHelper.IsPaused();
            float easedValue;
            while (fraction < 1)
            {
                fraction = fraction.To1(speed, isUnscaledTime, interpolator, out easedValue);
                Vector2 newScale = Vector2.Lerp(currntScale, scaleTo, easedValue);
                rectTransform.sizeDelta = newScale;
                yield return null;
            }
        }
        #endregion

        /// <summary>
        /// Moves from one size to another dynamically
        /// </summary>
        /// <param name="transform"> Transform obj to be scaled</param>
        /// <param name="scaleTo"> Scale to</param>
        /// <param name="time"> Time it takes to scale</param>
        /// <param name="interpolationFunction"> Scaling interpolator</param>
        /// <param name="isUnscaledTime"> Is not paused</param>
        /// <returns></returns>
        public static IEnumerator InterpolateRectPositionE(RectTransform rectTransform, Vector3 pointTo, float time = 1, Easings.Functions interpolationFunction = Easings.Functions.Linear)
        {
            //rectTransform.position = new Vector3(0, 0, 0);
            Vector3 currentPosition = rectTransform.localPosition;
            Easings.Function interpolator = Easings.GetInterpolator(interpolationFunction);
            float fraction = 0;
            float speed = 1 / time;
            bool isUnscaledTime = GeneralHelper.IsPaused();
            float easedValue;
            while (fraction < 1)
            {
                fraction = fraction.To1(speed, isUnscaledTime, interpolator, out easedValue);
                Vector3 newPosition = Vector3.Lerp(currentPosition, pointTo, easedValue);
                rectTransform.localPosition = newPosition;
                yield return null;
            }
        }

        #region Fancy Point Interpolation
        /// <summary>
        /// Curved interpolation of a point in 2D
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="locationTo"></param>
        /// <param name="time"></param>
        /// <param name="interpolationType"></param>
        /// <param name="rotationNormalised"></param>
        /// <param name="offsetZ"></param>
        /// <param name="isUnscaledTime"></param>
        /// <returns></returns>
        public static IEnumerator FancyInterpolation(Transform target, Vector3 locationTo, float time, Easings.Functions interpolationType = Easings.Functions.QuarticEaseInOut,
            bool rotationNormalised = true, float offsetZ = 0, bool isUnscaledTime = false)
        {
            const int functionsCount = 21; // based on Easings.Functions
            Easings.Functions typeOfInterpolationX = (Easings.Functions)UnityEngine.Random.Range(0, functionsCount);
            Easings.Functions typeOfInterpolationY = (Easings.Functions)UnityEngine.Random.Range(0, functionsCount);
            Easings.Function interpolatorX = Easings.GetInterpolator(typeOfInterpolationX);
            Easings.Function interpolatorY = Easings.GetInterpolator(typeOfInterpolationY);
            Easings.Function interpolatorFraction = Easings.GetInterpolator(interpolationType);
            float fraction = 0;
            float speed = 1 / time;
            Vector3 currentPosition = target.position + Vector3.forward * offsetZ;
            Quaternion currentRotation = target.rotation;
            Quaternion rotationTo = Quaternion.Euler(Vector3.zero);
            float totalDisanceX = locationTo.x - currentPosition.x;
            float totalDisanceY = locationTo.y - currentPosition.y;
            if (rotationNormalised)
            {
                while (fraction < 1)
                {
                    float resultX;
                    Vector3 offsetToMoveBy = FancyInterpolationSplitResult(totalDisanceX, totalDisanceY, fraction, speed, isUnscaledTime,
                    interpolatorFraction, interpolatorX, interpolatorY, out resultX);
                    target.position = currentPosition + offsetToMoveBy;
                    Quaternion newRotation = Quaternion.Lerp(currentRotation, rotationTo, resultX);
                    target.rotation = newRotation;
                    yield return null;
                }
            }
            else
            {
                while (fraction < 1)
                {
                    float resultX; // not used
                    Vector3 offsetToMoveBy = FancyInterpolationSplitResult(totalDisanceX, totalDisanceY, fraction, speed, isUnscaledTime,
                    interpolatorFraction, interpolatorX, interpolatorY, out resultX);
                    target.position = currentPosition + offsetToMoveBy;
                    yield return null;
                }
            }
        }

        /// <summary>
        /// The actual interpolation part of one step in fancy interpolator
        /// </summary>
        /// <param name="totalX"> Total distance intrepolated in x</param>
        /// <param name="totalY"> Total distance intrepolated in y</param>
        /// <param name="fraction"> Interpolation fraction</param>
        /// <param name="fractionChangeSpeed"> Interpolation fraction change speed</param>
        /// <param name="isUnscaledTime"> Is not paused</param>
        /// <param name="fractionInterpolator"> Function to interpolate fraction</param>
        /// <param name="interpolatorX"> Function to interpolate x value of point</param>
        /// <param name="interpolatorY"> Function to interpolate y value of point</param>
        /// <param name="resultX"> Interpolated x value to be returned for rotation (can be any of 3 fractions)</param>
        /// <returns></returns>
        private static  Vector3 FancyInterpolationSplitResult(float totalX, float totalY, float fraction, float fractionChangeSpeed, bool isUnscaledTime, 
        Easings.Function fractionInterpolator, Easings.Function interpolatorX, Easings.Function interpolatorY, out float resultX)
        {
            fraction.To1(fractionChangeSpeed, isUnscaledTime);
            float fractionNew = fractionInterpolator(fraction);
            resultX = interpolatorX(fractionNew);
            float resultY = interpolatorY(fractionNew);
            float newX = totalX * resultX;
            float newY = totalY * resultY;
            return new Vector3(newX, newY, 0);
        }
        #endregion
    }
}
