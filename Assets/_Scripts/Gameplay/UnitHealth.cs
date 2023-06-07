using System;

namespace _Scripts.Gameplay
{
    public class UnitHealth : HealthComponent
    {
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
                _hasBeenDamaged = true;
            }
            else if(!_isDead) 
                Die();
        }

        public override void Kill(Action callback = null)
        {
            callback?.Invoke();
            Die();
        }

        public override void Die()
        {
            OnDeadAction?.Invoke();
            _isDead = true;

            OnDeadAction = null;
            OnHealthChanged = null;
        }

        public override bool HasBeenDamaged()
        {
            if (_hasBeenDamaged)
            {
                _hasBeenDamaged = false;
                return true;
            }

            return false;
        }
    }
}