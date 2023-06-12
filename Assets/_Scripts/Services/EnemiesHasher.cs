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

        public delegate void EnemiesChanged(int amount);
        
        public EnemiesChanged OnEnemiesAmountChanged;
        
        public EnemiesHasher()
        {
        }

        public void Register(IEnemy enemy)
        {
            if(!Enemies.Contains(enemy))
            {
                Enemies.Add(enemy);
                OnEnemiesAmountChanged?.Invoke(Enemies.Count);
            }
        }

        public void Unregister(IEnemy enemy)
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
