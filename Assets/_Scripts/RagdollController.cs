using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts
{
    public class RagdollController: MonoBehaviour
    {
        [SerializeField] private Rigidbody[] _rigidbodies;
        [SerializeField] private Collider[] _colliders;

        private Transform _ragdollRoot;

        [Button]
        private void Reset()
        {
            if (_rigidbodies != null)
            {
                Array.Clear(_rigidbodies, 0, _rigidbodies.Length);
            }

            if (_colliders != null)
            {
                Array.Clear(_colliders, 0, _colliders.Length);
            }

            _rigidbodies = GetComponentsInChildren<Rigidbody>();
            _colliders = GetComponentsInChildren<Collider>();
        }

        private void Awake()
        {
            _ragdollRoot = transform;
        }

        public void AdjustRootTransform()
        {
            _ragdollRoot.root.position = _ragdollRoot.position;
        }

        public void EnableRagdoll()
        {
            foreach (var rigidbody in _rigidbodies)
                rigidbody.isKinematic = false;

            /*foreach (var collider in _colliders)
                collider.enabled = true;*/
        }
    
        public void DisableRagdoll()
        {
            foreach (var rb in _rigidbodies)
                rb.isKinematic = true;

            /*foreach (var collider in _colliders)
                collider.enabled = false;*/
        }
    }
}
