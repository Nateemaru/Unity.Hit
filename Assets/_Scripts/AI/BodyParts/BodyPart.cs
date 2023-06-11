using System;
using _Scripts.Gameplay;
using UnityEngine;

namespace _Scripts.AI.BodyParts
{
    public abstract class BodyPart : MonoBehaviour
    {
        public Action OnBodyPartPunched;
        protected HealthComponent _targetHealth;

        public abstract void Punch(Vector3 forceDirection);

        public void SetTargetHealth(HealthComponent healthComponent)
        {
            _targetHealth = healthComponent;
        }
    }
}