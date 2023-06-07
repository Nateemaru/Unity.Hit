using UnityEngine;

namespace _Scripts.Player
{
    public abstract class TargetBase : ITarget
    {
        public abstract Transform GetTarget();
    }
}