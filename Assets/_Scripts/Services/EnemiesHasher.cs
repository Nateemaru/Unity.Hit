using System.Collections.Generic;
using _Scripts.AI;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

namespace _Scripts.Services
{
    public class EnemiesHasher
    {
        [ReadOnly] public List<IEnemy> Enemies = new List<IEnemy>();

        public delegate void OnAmountChanged(int amount);
        
        public OnAmountChanged OnEnemiesAmountChanged;
        
        public EnemiesHasher()
        {
        }

        public void Add(IEnemy enemy)
        {
            if(!Enemies.Contains(enemy))
            {
                Enemies.Add(enemy);
                OnEnemiesAmountChanged?.Invoke(Enemies.Count);
            }
        }

        public void Remove(IEnemy enemy)
        {
            if(Enemies.Contains(enemy))
            {
                Enemies.Remove(enemy);
                OnEnemiesAmountChanged?.Invoke(Enemies.Count);
            }
            
            if(Enemies.IsNullOrEmpty())
                EventBus.RaiseEvent<INoEnemiesSubscriber>(item => item.OnNoEnemies());
        }
    }
}
