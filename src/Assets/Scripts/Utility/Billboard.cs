using UnityEngine;

namespace Utility
{
    public class Billboard : MonoBehaviour
    {
        [Tooltip("If not supplied, the billboard will use the main camera.")]
        [SerializeField]
        Transform LookAtTargetOverride;
        [SerializeField]
        bool LockRotationX;
        [SerializeField]
        bool LockRotationY;
        [SerializeField]
        bool LockRotationZ;

        Vector3 lookVector;

        Transform lookAtTarget;

        private void Awake()
        {
            if (LookAtTargetOverride == null)
            {
                lookAtTarget = Camera.main.transform;
            }
            else
            {
                lookAtTarget = LookAtTargetOverride;
            }
        }

        void Update()
        {
            lookVector = lookAtTarget.transform.position - transform.position;
           // if (lookVector != Vector3.zero)
           // {
                transform.rotation = Quaternion.LookRotation(-lookVector);

                transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x * (LockRotationX ? 0f : 1f),
                    transform.eulerAngles.y * (LockRotationY ? 0f : 1f),
                    transform.eulerAngles.z * (LockRotationZ ? 0f : 1f)));
           // }
        }
    }
}