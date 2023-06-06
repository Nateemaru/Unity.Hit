using UnityEngine;

namespace _Scripts
{
    public class FPSUnlocker : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }
}