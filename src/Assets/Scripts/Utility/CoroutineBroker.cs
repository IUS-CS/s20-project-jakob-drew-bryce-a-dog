using System.Collections;

namespace Utility
{
    public class CoroutineBroker : Singleton<CoroutineBroker>
    {
        public void StartRoutine(IEnumerator routine)
        {
            StartCoroutine(routine);
        }
    }
}