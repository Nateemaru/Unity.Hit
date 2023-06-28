using System;
using _Scripts.Services;
using _Scripts.Services.InputService;
using _Scripts.SO;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private PoolObjectConfig _bullet;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private LayerMask _targetMask;
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _inputService.OnTouched += Shoot;
        }

        private void Shoot(Vector3 position)
        {
            var ray = Camera.main.ScreenPointToRay(position);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _targetMask))
            {
                var obj = PoolHub.Instance.GetObject(_bullet);
                        
                obj.transform.localPosition = _firePoint.position;
                obj.transform.LookAt(hit.point, Vector3.up);
                if(obj.TryGetComponent(out Bullet bullet))
                    bullet.SetDirection(hit.point);
            }
        }

        private void OnDisable()
        {
            _inputService.OnTouched -= Shoot;
        }
    }
}