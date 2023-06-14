using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.CodeSugar;
using _Scripts.Factories;
using _Scripts.SO;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Scripts.Services
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private PoolObjectConfig _config;
        [SerializeField] private Transform _container;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private int _minCapacity;

        private List<GameObject> _pool;
        private bool _firstInitExecuted;
        private GameObjectFactory _factory;

        public PoolObjectConfig Type => _config;

        [Inject]
        private void Construct(GameObjectFactory factory)
        {
            _factory = factory;
        }

        private void Start()
        {
            InitPool();
        }

        private void InitPool()
        {
            if (_firstInitExecuted)
                return;
            
            _pool = new List<GameObject>();

            for (var i = 0; i < _minCapacity; i++)
                CreateObject();

            _firstInitExecuted = true;
        }

        public void InitPoolAfterStart(PoolObjectConfig type, Transform container, bool autoExpand, int minCapacity)
        {
            _config = type;
            _container = container;
            _autoExpand = autoExpand;
            _minCapacity = minCapacity;
            
            InitPool();
        }

        private GameObject CreateObject(bool defaultCondition = false)
        {
            var createdObject = _factory.CreateGameObject(_config.Prefab);
            createdObject.transform.parent = _container;
            createdObject.SetActive(defaultCondition);
            _pool.Add(createdObject);
            return createdObject;
        }

        public GameObject GetFreeObject()
        {
            if (HasFreeObject(out var element))
                return element;

            if (_autoExpand)
                return CreateObject(true);

            throw new Exception("There is no free element and not auto expand");
        }

        private bool HasFreeObject(out GameObject element)
        {
            foreach (var item in _pool)
            {
                if (!item.activeInHierarchy)
                {
                    element = item;
                    element.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }
    }
}
