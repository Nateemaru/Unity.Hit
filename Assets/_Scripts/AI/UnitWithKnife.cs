using System;
using _Scripts.Gameplay.FSM;
using _Scripts.Gameplay.States;
using Animancer;
using UnityEngine;

namespace _Scripts.AI
{
    public class UnitWithKnife : EnemyBase
    {
        [SerializeField] private AnimancerTransition _idleClip;
        [SerializeField] private AnimancerTransition _moveClip;
        [SerializeField] private AnimancerTransition _attackClip;
        [SerializeField] private float _getUpDelay;

        private float _timer;
        
        protected override void Init()
        {
            _timer = _getUpDelay;
            
            var idleState = new IdleState(_animancer, _idleClip);
            var moveState = new EnemyMoveState(transform, _animancer, _moveClip, _config.Speed, _target.GetTarget());
            var ragdollState = new RagdollState(transform, _animancer, _puppetMaster, _target);
            
            _fsm = new FSM();
            _fsm.SetState(idleState);
            
            _fsm.AddAnyTransition(ragdollState, () => _health.HasBeenDamaged());
            
            _fsm.AddAnyTransition(idleState, () => _target.GetTarget() == null 
                                                   || _fsm.CurrentState.IsAnimationEnded
                                                   && !_animancer.Animator.enabled);
            
            _fsm.AddAnyTransition(moveState, () => _target.GetTarget() != null
                                                   && _animancer.Animator.enabled
                                                   && !_puppetMaster.isBlending);
        }

        protected override void Update()
        {
            base.Update();

            if (_fsm.CurrentState.GetType() == typeof(RagdollState))
            {
                _timer -= Time.deltaTime;

                if (_health.HasBeenDamaged())
                    _timer = _getUpDelay;

                if (_timer <= 0)
                {
                    _fsm.CurrentState.Exit();
                    _timer = _getUpDelay;
                }
            }

        }
    }
}