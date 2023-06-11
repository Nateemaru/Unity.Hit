using System;
using System.Collections;
using _Scripts.CodeSugar;
using _Scripts.Gameplay;
using DG.Tweening;
using UnityEngine;

namespace _Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private bool _isHit;

        private void Update()
        {
            if(!_isHit)
                transform.position += transform.forward * (_speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            transform.GetComponent<Collider>().enabled = false;
            _isHit = true;
            
            if(other.transform.root.GetComponentInChildren<HealthComponent>() != null)
                other.transform.root.GetComponentInChildren<HealthComponent>().ApplyDamage(1);
            
            if (other.TryGetComponent(out Rigidbody rb))
            {
                transform.SetParent(rb.transform);
                
                var forceDir = (other.transform.position - Camera.main.transform.position);
                forceDir.y = 0f;
                forceDir.Normalize();
                rb.AddForce(forceDir * 50, ForceMode.Impulse);
            }
        }
    }
}