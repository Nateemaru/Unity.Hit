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
        private Dictionary<VfxConfig, ObjectPool> _pools;
        private PoolFactory _factory;

        public static PoolHub Instance => _instance;

        [Inject]
        private void Construct(PoolFactory factory)
        {
            _factory = factory;
        }

        private void Start()
        {
            if (_instance != null && _instance != this)
                Destroy(gameObject);
            else
            {
                _instance = this;
            }
            
            _pools = new Dictionary<VfxConfig, ObjectPool>();
            _setupPools = GetComponentsInChildren<ObjectPool>();

            foreach (var pool in _setupPools)
            {
                _pools.Add(pool.Type, pool);
            }
        }
    
        private void CreatePool(VfxConfig poolType, Transform parent = null)
        {
            if (_pools.ContainsKey(poolType))
                return;

            ObjectPool newPool;

            newPool = _factory.CreatePool(gameObject);
            
            var container = parent != null ? parent : transform;
            newPool.InitPoolAfterStart(poolType, container, true, 1);

            _pools.Add(poolType, newPool);
        }

        public GameObject GetObject(VfxConfig type, Transform parent = null)
        {
            if (!_pools.ContainsKey(type))
                CreatePool(type, parent);

            return _pools[type].GetFreeObject();
        }
    }
}