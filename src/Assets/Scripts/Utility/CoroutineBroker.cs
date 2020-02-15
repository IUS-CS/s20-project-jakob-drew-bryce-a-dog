using System.Collections;

namespace Samtec.OpticsVRTrainer.Utility
{
    public class CoroutineBroker : Singleton<CoroutineBroker>
    {
        public void StartRoutine(IEnumerator routine)
        {
            StartCoroutine(routine);
        }
    }
}