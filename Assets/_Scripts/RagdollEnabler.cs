using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts
{
    public class RagdollEnabler: MonoBehaviour
    {
        [SerializeField] private Rigidbody[] _rigidbodies;
        [SerializeField] private Collider[] _colliders;
        [SerializeField] private bool _isActiveOnStart;

        private bool _isEnable;

        public bool IsEnable => _isEnable;

        [Button]
        private void Reset()
        {
            if (_rigidbodies != null)
                Array.Clear(_rigidbodies, 0, _rigidbodies.Length);

            if (_colliders != null)
                Array.Clear(_colliders, 0, _colliders.Length);

            _rigidbodies = GetComponentsInChildren<Rigidbody>();
            _colliders = GetComponentsInChildren<Collider>();
        }

        private void Start()
        {
            if(_isActiveOnStart)
                EnableRagdoll();
        }

        public void EnableRagdoll()
        {
            foreach (var rigidbody in _rigidbodies)
                rigidbody.isKinematic = false;

            _isEnable = true;

            /*foreach (var collider in _colliders)
                collider.enabled = true;*/
        }
    
        public void DisableRagdoll()
        {
            foreach (var rb in _rigidbodies)
                rb.isKinematic = true;

            _isEnable = false;

            /*foreach (var collider in _colliders)
                collider.enabled = false;*/
        }
    }
}
