using System.Collections.Generic;
using _Scripts.Factories;
using _Scripts.SO;
using UnityEngine;
using Zenject;

namespace _Scripts.Services
{
    public class PoolHub : MonoBehaviour
    {
        private static PoolHub _instance;
        private ObjectPool[] _setupPools;
        private Dictionary<string, ObjectPool> _pools;
        private ObjectPool.Factory _factory;

        public static PoolHub Instance => _instance;

        [Inject]
        private void Construct(ObjectPool.Factory factory)
        {
            _factory = factory;
        }

        private void Start()
        {
            if (_instance != null && _instance != this)
                Destroy(gameObject);
            else
                _instance = this;
            
            _pools = new Dictionary<string, ObjectPool>();
            _setupPools = GetComponentsInChildren<ObjectPool>();

            foreach (var pool in _setupPools)
            {
                _pools.Add(pool.ObjectName, pool);
            }
        }
    
        private void CreatePool(GameObject prefab, Transform parent = null)
        {
            if (_pools.ContainsKey(prefab.name))
                return;

            ObjectPool newPool;

            newPool = _factory.Create();
            newPool.transform.parent = transform;
            
            var container = parent != null ? parent : newPool.transform;
            newPool.InitPoolAfterStart(prefab, container, true, 5);

            _pools.Add(prefab.name, newPool);
        }

        public GameObject GetObject(GameObject prefab, Transform parent = null)
        {
            if (!_pools.ContainsKey(prefab.name))
                CreatePool(prefab, parent);

            return _pools[prefab.name].GetFreeObject();
        }
    }
}