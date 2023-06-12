using UnityEngine;

namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IEnemyDiedSubscriber : IGlobalSubscriber
    {
        public void OnEnemyDied(Transform deadTransform);
    }
}