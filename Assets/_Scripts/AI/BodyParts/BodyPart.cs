using System;
using _Scripts.Gameplay;
using UnityEngine;

namespace _Scripts.AI.BodyParts
{
    public abstract class BodyPart : MonoBehaviour
    {
        public Action OnBodyPartPunched;
        protected HealthComponent _targetHealth;

        public virtual void Punch(Vector3 forceDirection, Action callback = null)
        {
            if(_targetHealth != null && !_targetHealth.IsDead)
                callback?.Invoke();
        }

        public void SetTargetHealth(HealthComponent healthComponent)
        {
            _targetHealth = healthComponent;
        }
    }
}