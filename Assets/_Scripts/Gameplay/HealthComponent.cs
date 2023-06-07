using System;
using UnityEngine;

namespace _Scripts.Gameplay
{
    public abstract class HealthComponent : MonoBehaviour
    {
        protected float _maxHp;
        protected float _currentHp;
        protected bool _isDead;
        protected bool _hasBeenDamaged;
        public float MaxHp => _maxHp;

        public float CurrentHp => _currentHp;

        public bool IsDead => _isDead;

        public Action OnDeadAction;
        public Action OnHealthChanged;

        public abstract void Initialize(float hp);
        public abstract void ApplyDamage(float damage, Action callback = null);
        public abstract void Kill(Action callback = null);

        public abstract void Die();
        public abstract bool HasBeenDamaged();
    }
}