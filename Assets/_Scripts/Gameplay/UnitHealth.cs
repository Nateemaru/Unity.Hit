using System;
using _Scripts.Tweens;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.Gameplay
{
    public class UnitHealth : HealthComponent
    {
        [SerializeField] private bool _isChangeMaterialOnDeath;
        [ShowIf("_isChangeMaterialOnDeath")] [SerializeField] private MaterialChanger _materialChanger;
        
        public override void Initialize(float hp)
        {
            _maxHp = hp;
            _currentHp = hp;
        }

        public override void ApplyDamage(float damage, Action callback = null)
        {
            _currentHp -= damage;
        
            callback?.Invoke();
            OnHealthChanged?.Invoke();
            
            if (_currentHp > 0)
            {
            }
            else if(!_isDead) 
                Die();
        }

        public override void Kill(Action callback = null)
        {
            callback?.Invoke();
            ApplyDamage(_maxHp);
        }

        public override void Die()
        {
            if(_isChangeMaterialOnDeath)
                _materialChanger.Play();
            
            OnDeadAction?.Invoke();
            _isDead = true;

            OnDeadAction = null;
            OnHealthChanged = null;
        }
    }
}