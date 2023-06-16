using UnityEngine;

namespace _Scripts
{
    public class FPSUnlocker
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }
}