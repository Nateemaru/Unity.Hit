using System;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using UnityEngine;

namespace _Scripts.Player
{
    [RequireComponent(typeof(MovementBase))]
    public class PlayerController : MonoBehaviour, 
                                    ITarget,
                                    IPlayerJumpSubscriber,
                                    IPlayerMoveSubscriber,
                                    IPlayerStopSubscriber
    {
        [SerializeField] private float _speedXZ;
        [SerializeField] private float _speedY;
        
        private MovementBase _movement;

        private void Start()
        {
            _movement = GetComponent<MovementBase>();
            EventBus.Subscribe(this);
        }

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public Transform GetTarget()
        {
            return transform;
        }

        public void OnPlayerJumped()
        {
            _movement.SetSpeed(_speedY);
        }

        public void OnPlayerMove()
        {
            _movement.SetSpeed(_speedXZ);
        }

        public void OnPlayerStopped()
        {
            _movement.SetSpeed(0);
        }
    }
}
