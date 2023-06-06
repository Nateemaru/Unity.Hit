using UnityEngine;

namespace _Scripts.Services.InputService
{ 
    public abstract class InputBase : MonoBehaviour, IInputService
    {
        public abstract Vector3 GetDirection();
    }
}