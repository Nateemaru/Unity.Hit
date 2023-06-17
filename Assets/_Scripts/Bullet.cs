using System;
using _Scripts.AI.BodyParts;
using _Scripts.CodeSugar;
using _Scripts.Services;
using _Scripts.SO;
using DG.Tweening;
using Sirenix.OdinInspector;
using TrailsFX;
using UnityEngine;

namespace _Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private ProjectileConfig _config;
        [SerializeField] private TrailEffect _trail;

        [SerializeField] private bool _hasHitEffect;
        [ShowIf("_hasHitEffect")] [SerializeField] private PoolObjectConfig _hitVfxEffect;
        
        private Vector3 _direction;
        private bool _isHit;

        private void Update()
        {
            if (_isHit) 
                return;

            if(_direction != Vector3.zero)
                transform.position += transform.forward * (_config.Speed * Time.deltaTime);
        }

        public void SetDirection(Vector3 direction) => _direction = direction;

        private void OnTriggerEnter(Collider other)
        {
            _trail.enabled = false;
            _isHit = true;
            transform.GetComponent<Collider>().enabled = false;
            
            if(other.TryGetComponent(out BodyPart bodyPart))
            {
                PoolHub.Instance.GetObject(_hitVfxEffect).transform.position = transform.position;
                bodyPart.Punch(other.transform.position - transform.forward);
                transform.parent = other.transform;
            }
        }
    }
}