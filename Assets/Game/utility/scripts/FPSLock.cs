using UnityEngine;

namespace Core.Application
{
    public class FPSLock : MonoBehaviour
    {
        [SerializeField] private int _targetFPS;

        private void Awake()
        {
            UnityEngine.Application.targetFrameRate = _targetFPS;
            // QualitySettings.vSyncCount = 0;
        }
    }
}