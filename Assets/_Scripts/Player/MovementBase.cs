using UnityEngine;

namespace _Scripts.Player
{
    public abstract class MovementBase : MonoBehaviour
    {
        protected float _speed;

        public abstract void SetSpeed(float value);
    }
}