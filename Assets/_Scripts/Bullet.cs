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

        private Vector3 _targetPos;

        private bool _isHit;

        private void Update()
        {
            if(!_isHit)
            {
                if (_targetPos != Vector3.zero)
                    transform.position += (_targetPos - transform.position).normalized * (_config.Speed * Time.deltaTime);

                //transform.rotation *= Quaternion.AngleAxis(_config.RotationSpeed, Vector3.right);
            }
        }

        public void SetTarget(Vector3 targetPosition) => _targetPos = targetPosition;

        private void OnTriggerEnter(Collider other)
        {
            _isHit = true;
            _targetPos = Vector3.zero;
            transform.GetComponent<Collider>().enabled = false;
            
            if(other.TryGetComponent(out BodyPart bodyPart))
            {
                transform.parent = other.transform;
                bodyPart.Punch(other.transform.position - Camera.main.transform.position);
            }
        }
    }
}