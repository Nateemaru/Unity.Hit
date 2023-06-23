using System;
using System.Collections.Generic;
using _Scripts.AI;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace _Scripts.Services
{
    public class EnemiesHasher
    {
        private List<IEnemy> _enemies = new List<IEnemy>();
        private float _totalEnemies;
        public List<IEnemy> Enemies => _enemies;
        public float TotalEnemies;
        
        public Action OnEnemiesAmountChanged;

        public void Register(IEnemy enemy)
        {
            if(!_enemies.Contains(enemy))
            {
                _enemies.Add(enemy);
                OnEnemiesAmountChanged?.Invoke();
                TotalEnemies++;
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
    }
}
