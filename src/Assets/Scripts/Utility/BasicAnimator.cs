using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Utility
{
    /// <summary>
    /// Handles basic interpolation animations for typical transform properties.  Invoke callbacks on complete as needed.
    /// </summary>
    public class BasicAnimator
    {
        public static IEnumerator AnimateScale(Transform transformToScale, Vector3 startScale, Vector3 endScale, float animationTime, Action callback = null, float delayTime = 0)
        {
            yield return new WaitForSeconds(delayTime);

            var startTime = Time.time;
            var interpolationValue = 0f;

            while (transformToScale.localScale != endScale)
            {
                interpolationValue = Mathf.SmoothStep(0f, 1f, (Time.time - startTime) / animationTime);

                transformToScale.localScale = Vector3.Lerp(startScale, endScale, interpolationValue);

                yield return null;
            }

            if (callback != null)
            {
                callback.Invoke();
            }
        }
        public static IEnumerator AnimateWorldPosition(Transform transformToTranslate, Vector3 startWorldPosition, Vector3 endWorldPosition, float animationTime, Action callback = null, float delayTime = 0)
        {
            yield return new WaitForSeconds(delayTime);

            var startTime = Time.time;
            var interpolationValue = 0f;

            while (transformToTranslate.position != endWorldPosition)
            {
                interpolationValue = Mathf.SmoothStep(0f, 1f, (Time.time - startTime) / animationTime);

                transformToTranslate.position = Vector3.Lerp(startWorldPosition, endWorldPosition, interpolationValue);

                yield return null;
            }

            if (callback != null)
            {
                callback.Invoke();
            }
        }
        public static IEnumerator AnimateLocalPosition(Transform transformToTranslate, Vector3 startLocalPosition, Vector3 endLocalPosition, float animationTime, Action callback = null)
        {
            var startTime = Time.time;
            var interpolationValue = 0f;

            while (transformToTranslate.localPosition != endLocalPosition)
            {
                interpolationValue = Mathf.SmoothStep(0f, 1f, (Time.time - startTime) / animationTime);

                transformToTranslate.localPosition = Vector3.Lerp(startLocalPosition, endLocalPosition, interpolationValue);

                yield return null;
            }

            if (callback != null)
            {
                callback.Invoke();
            }
        }
        public static IEnumerator AnimateWorldRotation(Transform transformToRotate, Quaternion startWorldRotation, Quaternion endWorldRotation, float animationTime)
        {
            var startTime = Time.time;
            var interpolationValue = 0f;

            while (transformToRotate.rotation != endWorldRotation)
            {
                interpolationValue = Mathf.SmoothStep(0f, 1f, (Time.time - startTime) / animationTime);

                transformToRotate.rotation = Quaternion.Slerp(startWorldRotation, endWorldRotation, interpolationValue);

                yield return null;
            }
        }
        public static IEnumerator AnimateLocalRotation(Transform transformToRotate, Quaternion startLocalRotation, Quaternion endLocalRotation, float animationTime)
        {
            var startTime = Time.time;
            var interpolationValue = 0f;

            while (transformToRotate.localRotation != endLocalRotation)
            {
                interpolationValue = Mathf.SmoothStep(0f, 1f, (Time.time - startTime) / animationTime);

                transformToRotate.localRotation = Quaternion.Slerp(startLocalRotation, endLocalRotation, interpolationValue);

                yield return null;
            }
        }

        public static IEnumerator AnimateImageFade(Image imageToFade, float startAlpha, float endAlpha, float animationTime)
        {
            var startTime = Time.time;
            var interpolationValue = 0f;
            Color color;

            while (imageToFade.color.a != endAlpha)
            {
                interpolationValue = Mathf.SmoothStep(0f, 1f, (Time.time - startTime) / animationTime);

                color = imageToFade.color;
                color.a = Mathf.Lerp(startAlpha, endAlpha, interpolationValue);
                imageToFade.color = color;

                yield return null;
            }
        }

        public static IEnumerator AnimateImageColor(Image imageToChange, Color startColor, Color endColor, float animationTime)
        {
            var startTime = Time.time;
            var interpolationValue = 0f;

            while (imageToChange.color != endColor)
            {
                interpolationValue = Mathf.SmoothStep(0f, 1f, (Time.time - startTime) / animationTime);

                imageToChange.color = Color.Lerp(startColor, endColor, interpolationValue);

                yield return null;
            }
        }

        public static IEnumerator AnimateImageFill(Image imageToFill, float startFill, float endFill, float animationTime, Action callback = null)
        {
            var startTime = Time.time;
            var interpolationValue = 0f;

            while (imageToFill.fillAmount != endFill)
            {
                interpolationValue = Mathf.SmoothStep(0f, 1f, (Time.time - startTime) / animationTime);

                imageToFill.fillAmount = Mathf.Lerp(startFill, endFill, interpolationValue);

                yield return null;
            }

            if (callback != null)
            {
                callback.Invoke();
            }
        }
    }
}