using System;
using _Scripts.Services;
using _Scripts.SO;
using UnityEngine;

namespace _Scripts.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class ExplosionBarrel : MonoBehaviour
    {
        [SerializeField] private float _explosionForce;
        [SerializeField] private float _explosionJumpForce;
        [SerializeField] private float _radius;
        [SerializeField] private GameObject _poolObjectConfig;
        
        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].TryGetComponent(out HealthComponent health))
                    health.Kill();
            }
            
            for (int i = 0; i < colliders.Length; i++)
            {
                var rb = colliders[i].attachedRigidbody;
                
                if (rb)
                    rb.AddExplosionForce(_explosionForce, transform.position, _radius, _explosionJumpForce);
            }
            
            _rb.AddForce((Vector3.right + Vector3.up) * _explosionJumpForce, ForceMode.Force);
            _rb.AddTorque((Vector3.right + Vector3.up) * _explosionJumpForce);
            PoolHub.Instance.GetObject(_poolObjectConfig).transform.position = transform.position;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bullet bullet))
                Explode();
        }
    }
}