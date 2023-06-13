using System;
using _Scripts.Services;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Camera
{ 
    public class CameraTargetController : MonoBehaviour, IEnemyGroupSubscriber
    {
        [SerializeField] private CinemachineTargetGroup[] _targetGroup;

        private CamerasHasher _camerasHasher;
        private int _groupCount = 1;

        [Inject]
        private void Construct(CamerasHasher camerasHasher)
        {
            _camerasHasher = camerasHasher;
        }

        private void Start()
        {
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

        private void ChangeTargetGroup()
        {
            if(_groupCount < _targetGroup.Length)
                _camerasHasher.ActiveCamera.LookAt = _targetGroup[_groupCount++].transform;
        }

        public void OnGroupIsEmpty()
        {
            ChangeTargetGroup();
        }
    }
}