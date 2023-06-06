using _Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Scripts.Factories
{
    public class PoolFactory : PlaceholderFactory<ObjectPool>
    {
        private DiContainer _container;

        public PoolFactory(DiContainer container)
        {
            _container = container;
        }

        public ObjectPool CreatePool(GameObject parent)
        {
            var pool = _container.InstantiateComponent<ObjectPool>(parent);
            return pool;
        }
    }
}