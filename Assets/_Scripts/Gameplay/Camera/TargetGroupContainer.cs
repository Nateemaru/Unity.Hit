using System;
using _Scripts.AI;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using Cinemachine;
using UnityEngine;

namespace _Scripts.Gameplay.Camera
{
    [RequireComponent(typeof(CinemachineTargetGroup))]
    public class TargetGroupContainer : MonoBehaviour, IEnemyDiedSubscriber
    {
        private CinemachineTargetGroup _targetGroup;

        public Action OnContainerIsEmpty;

        private void Start()
        {
            _targetGroup = GetComponent<CinemachineTargetGroup>();
            EventBus.Subscribe(this);
        }

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
            OnContainerIsEmpty = null;
        }

        public void OnEnemyDied(Transform deadTransform)
        {
            for (int i = 0; i < _targetGroup.m_Targets.Length; i++)
            {
               var targetTransform = _targetGroup.m_Targets[i].target;
               
               if(targetTransform != null && targetTransform == deadTransform) 
                   _targetGroup.RemoveMember(targetTransform);
            }
            
            if(_targetGroup.m_Targets.Length <= 0)
            {
                OnContainerIsEmpty?.Invoke();
                EventBus.RaiseEvent<IEnemyGroupSubscriber>(item => item.OnGroupIsEmpty());
                EventBus.Unsubscribe(this);
            }
        }
    }
}