using UnityEngine;

namespace Utility
{
    /// <summary>
    /// Even with rigid body constraints, we're getting some drift on the droplet after repeat collisions - apply this as a bandaid for now...
    /// </summary>
    public class LocalPositionConstraintHandler : MonoBehaviour
    {
        Vector3 startLocalPosition;

        void Start()
        {
            startLocalPosition = transform.localPosition;
        }

        void Update()
        {
            transform.localPosition = startLocalPosition;
        }
    }
}