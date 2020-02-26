using UnityEngine;

namespace Utility
{
    /// <summary>
    /// This class contains math related helper functions.
    /// </summary>
    public class MathHelper
    {
        //provide a normalized (0-1) value based on an arbitrary range
        public static float NormalizeRange(float value, float min, float max)
        {
            return (value - min) / (max - min);
        }

        public static float GetAngleFromDirection(Vector2 direction)
        {
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        // input 5, 0, 10, 0, 30
        // return 15
        public static float ScaleFloat(float value, float OldMin, float OldMax, float NewMin, float NewMax)
        {
            float OldRange = (OldMax - OldMin);
            float NewRange = (NewMax - NewMin);

            return ((((value - OldMin) * NewRange) / OldRange) + NewMin);
        }
    }
}