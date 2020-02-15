using UnityEngine;

namespace Samtec.OpticsVRTrainer.Utility
{
    public class RayCastHelper
    {
        public static bool HitTarget(Vector3 origin, Vector3 direction, Collider targetCollider, float distance = 1f)
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(origin, direction, out hitInfo, distance))
            {
                if (hitInfo.collider == targetCollider)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool HitTarget(Vector3 origin, Vector3 direction, string targetName, float distance = 1f)
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(origin, direction, out hitInfo, distance))
            {
                if (hitInfo.collider.name == targetName)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool HitTarget(Vector3 origin, Vector3 direction, Collider targetCollider, LayerMask mask, float distance = 3f)
        {
            RaycastHit hitInfo;

            Debug.DrawRay(origin, Vector3.down);

            if (Physics.Raycast(origin, direction, out hitInfo, distance, mask))
            {
                if (hitInfo.collider == targetCollider)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool HitTarget(Vector3 origin, Vector3 direction, string targetName, LayerMask mask, float distance = 1f)
        {
            RaycastHit hitInfo;

            Debug.DrawRay(origin, Vector3.down);

            if (Physics.Raycast(origin, direction, out hitInfo, distance, mask))
            {
                if (hitInfo.collider.name == targetName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}