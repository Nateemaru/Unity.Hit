using System;
using _Scripts.Gameplay.FSM;
using _Scripts.Gameplay.States;
using _Scripts.Services;
using _Scripts.SO;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.Player
{
    public class Weapon : MonoBehaviour
    {
        [TabGroup("Param")][SerializeField] private LayerMask _targetMask;
        [TabGroup("Param")][SerializeField] private float _shootingDelay;
        [TabGroup("Param")][SerializeField] private int _bulletsInClip;
        [TabGroup("Param")][SerializeField] private VfxConfig _bulletDecalVfx;
        [TabGroup("Anim")] [SerializeField] private AnimancerTransition _idleClip;
        [TabGroup("Anim")] [SerializeField] private AnimancerTransition _shootClip;
        [TabGroup("Anim")] [SerializeField] private AnimancerTransition _reloadClip;


        private AnimancerComponent _animancer;
        private FSM _fsm;

        private void Start()
        {
            _animancer = GetComponent<AnimancerComponent>();
            Init();
        }

        private void Update()
        {
            _fsm?.UpdateMachine();
        }

        private void Init()
        {
            var idleState = new IdleState(_animancer, _idleClip);
            var shootState = new ShootState(_animancer, _shootClip, _targetMask, _shootingDelay, _bulletDecalVfx);
            
            _fsm = new FSM();
            _fsm.SetState(idleState);
            
            _fsm.AddAnyTransition(idleState, () => !IsTargetInScope() && _fsm.CurrentState.IsAnimationEnded);
            _fsm.AddAnyTransition(shootState, () => IsTargetInScope() && _fsm.CurrentState.IsAnimationEnded);
        }

        private bool IsTargetInScope()
        {
            var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out var hit, _targetMask))
            {
                return true;
            }

            return false;
        }
    }
}