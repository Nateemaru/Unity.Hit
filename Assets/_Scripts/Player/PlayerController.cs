using System;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using _Scripts.Services.InputService;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    [RequireComponent(typeof(MovementBase))]
    [RequireComponent(typeof(PlayerShoot))]
    public class PlayerController : MonoBehaviour, ITarget, IRemoteControllable
    {
        [SerializeField] private float _speedXZ;
        [SerializeField] private float _speedY;
        
        private MovementBase _movement;
        private PlayerShoot _shootComponent;
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _movement = GetComponent<MovementBase>();
            _shootComponent = GetComponent<PlayerShoot>();

            _inputService.OnTouched += Shoot;
        }

        private void Shoot(Vector3 position)
        {
            //if arms animation is playing return else play animation and shoot
            _shootComponent.Shoot(position);
        }

        public Transform GetTarget()
        {
            return transform;
        }

        public void Stop()
        {
            if(_movement)
                _movement.SetSpeed(0);
        }

        public void Move()
        {
            if(_movement)
                _movement.SetSpeed(_speedXZ);
        }

        public void Jump()
        {
            if(_movement)
                _movement.SetSpeed(_speedY);
        }
    }
}
