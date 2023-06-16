using System;
using _Scripts.AI.BodyParts;
using _Scripts.CodeSugar;
using _Scripts.SO;
using DG.Tweening;
using UnityEngine;

namespace _Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private ProjectileConfig _config;
        private Vector3 _direction;
        private bool _isHit;

        private void Update()
        {
            if (_isHit) 
                return;

            if(_direction != Vector3.zero)
                transform.position += (_direction - transform.position).normalized * (_config.Speed * Time.deltaTime);
        }

        public void SetDirection(Vector3 direction) => _direction = direction;

        private void OnTriggerEnter(Collider other)
        {
            _isHit = true;
            transform.GetComponent<Collider>().enabled = false;
            
            if(other.TryGetComponent(out BodyPart bodyPart))
            {
                bodyPart.Punch(other.transform.position - transform.forward);
                transform.parent = other.transform;
            }
        }
    }
}