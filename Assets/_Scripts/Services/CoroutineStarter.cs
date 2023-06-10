using System.Collections;
using UnityEngine;

namespace _Scripts.Services
{
    public sealed class CoroutineStarter : MonoBehaviour
    {
        private static CoroutineStarter _instance;

        public static CoroutineStarter Instance => _instance;

        private void Start()
        {
            if (_instance != null && _instance != this)
                Destroy(gameObject);
            else
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
        }

        public void StartRoutine(IEnumerator enumerator)
        {
            StartCoroutine(enumerator);
        }

        public void StopRoutine(IEnumerator enumerator)
        {
            StopCoroutine(enumerator);
        }
    }
}