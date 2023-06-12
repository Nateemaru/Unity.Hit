using System;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using Cinemachine;
using UnityEngine;

namespace _Scripts.Gameplay.Camera
{ 
    public class CameraTargetController : MonoBehaviour, IEnemyGroupSubscriber
    {
        [SerializeField] private CinemachineTargetGroup[] _targetGroup;
        [SerializeField] private CinemachineVirtualCamera _mainVCam;

        private int _groupCount = 1;

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
                _mainVCam.LookAt = _targetGroup[_groupCount++].transform;
        }

        public void OnGroupIsEmpty()
        {
            ChangeTargetGroup();
        }
    }
}