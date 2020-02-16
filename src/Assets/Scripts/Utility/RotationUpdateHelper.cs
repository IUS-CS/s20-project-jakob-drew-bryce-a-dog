using UnityEngine;

namespace Samtec.OpticsVRTrainer.Utility
{
    public class RotationUpdateHelper : MonoBehaviour
    {
        [SerializeField]
        Vector3 RotationDirection;

        private void Update()
        {
            transform.rotation = Quaternion.Euler(RotationDirection);
        }
    }
}