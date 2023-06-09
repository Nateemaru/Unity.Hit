using System;
using System.Collections;
using _Scripts.CodeSugar;
using _Scripts.Gameplay;
using UnityEngine;

namespace _Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _disableDelay;

        private bool _isHit;

        private void Update()
        {
            if(!_isHit)
                transform.position += transform.forward * (_speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.root.GetComponent<HealthComponent>() != null)
                other.transform.root.GetComponent<HealthComponent>().ApplyDamage(1);
            
            if (other.TryGetComponent(out Rigidbody rb))
            {
                transform.SetParent(rb.transform);
                var forceDir = (other.transform.position - Camera.main.transform.position).normalized;
                forceDir.y = 0f;
                rb.AddForce(forceDir * 25, ForceMode.Impulse);
            }

            transform.GetComponent<Collider>().enabled = false;
            _isHit = true;
            StartCoroutine(DisableRoutine());
        }

        private IEnumerator DisableRoutine()
        {
            yield return new WaitForSeconds(_disableDelay);
            transform.parent = null;
            _isHit = false;
            transform.GetComponent<Collider>().enabled = true;
            transform.Disable();
        }
    }
}