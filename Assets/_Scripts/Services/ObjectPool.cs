using System;
using System.Collections.Generic;
using _Scripts.Factories;
using _Scripts.SO;
using UnityEngine;
using Zenject;

namespace _Scripts.Services
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private VfxConfig _type;
        [SerializeField] private Transform _container;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private int _minCapacity;

        private List<GameObject> _pool;
        private bool _firstInitExecuted;
        private GameObjectFactory _factory;

        public VfxConfig Type => _type;

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

        public void InitPoolAfterStart(VfxConfig type, Transform container, bool autoExpand, int minCapacity)
        {
            _type = type;
            _container = container;
            _autoExpand = autoExpand;
            _minCapacity = minCapacity;
            
            InitPool();
        }

        private GameObject CreateObject(bool defaultCondition = false)
        {
            var createdObject = _factory.CreateGameObject(_type.Prefab);
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
