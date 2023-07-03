using UnityEngine;

namespace _Scripts
{
    public class FPSUnlocker
    {
        public FPSUnlocker()
        {
            Application.targetFrameRate = 60;
        }
    }
}