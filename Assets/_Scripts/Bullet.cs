using System;
using _Scripts.AI.BodyParts;
using _Scripts.CodeSugar;
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
            transform.SetParent(other.transform);
            
            if(other.TryGetComponent(out BodyPart bodyPart))
                bodyPart.Punch(other.transform.position - Camera.main.transform.position);
        }
    }
}