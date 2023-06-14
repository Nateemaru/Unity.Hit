using System;
using _Scripts.Services;
using _Scripts.SO;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private PoolObjectConfig _bullet;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private LayerMask _targetMask;
        
        private void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _targetMask))
                {
                    var obj = PoolHub.Instance.GetObject(_bullet);
                        
                    obj.transform.position = _firePoint.position;
                    obj.transform.LookAt(hit.point, Vector3.up);
                    if(obj.TryGetComponent(out Bullet bullet))
                        bullet.SetTarget(hit.point);
                }
            }
        }
    }
}