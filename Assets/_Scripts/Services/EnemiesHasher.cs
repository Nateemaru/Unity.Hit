using System;
using System.Collections.Generic;
using _Scripts.AI;

namespace _Scripts.Services
{
    public class EnemiesHasher
    {
        private List<IEnemy> _enemies = new List<IEnemy>();
        private float _totalEnemies;
        public List<IEnemy> Enemies => _enemies;
        public float TotalEnemies => _totalEnemies;
        
        public Action OnEnemiesAmountChanged;

        public void Register(IEnemy enemy)
        {
            if(!_enemies.Contains(enemy))
            {
                _enemies.Add(enemy);
                OnEnemiesAmountChanged?.Invoke();
                _totalEnemies++;
            }
        }

        public void Unregister(IEnemy enemy)
        {
            if(_enemies.Contains(enemy))
            {
                _enemies.Remove(enemy);
                OnEnemiesAmountChanged?.Invoke();
            }
        }

        public void Clear() => _enemies.Clear();
    }
}
