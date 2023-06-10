using System;
using _Scripts.CodeSugar;
using _Scripts.Gameplay.FSM;
using _Scripts.Gameplay.States;
using Animancer;
using UnityEngine;

namespace _Scripts.AI
{
    public class HumanEnemy : EnemyBase
    {
        [SerializeField] private AnimancerTransition _idleClip;
        [SerializeField] private AnimancerTransition _moveClip;
        [SerializeField] private AnimancerTransition _attackClip;
        [SerializeField] private float _getUpDelay;

        private float _getUpTimer;
        
        protected override void Init()
        {
            _getUpTimer = _getUpDelay;
            
            var idleState = new IdleState(_animancer, _idleClip);
            var moveState = new EnemyMoveState(transform, _animancer, _moveClip, _puppetMaster, _target);
            var ragdollState = new RagdollState(transform, _animancer, _puppetMaster, _target);
            
            _fsm = new FSM();
            _fsm.SetState(idleState);

            _health.OnHealthChanged += () =>
            {
                _getUpTimer = _getUpDelay;
                _fsm.SetState(ragdollState);
            };
            
            _fsm.AddAnyTransition(idleState, () => _target.GetTarget() == null 
                                                   || _fsm.CurrentState.IsAnimationEnded);
            
            _fsm.AddAnyTransition(moveState, () => _target.GetTarget() != null
                                                   && _fsm.CurrentState.IsAnimationEnded);
        }

        protected override void Update()
        {
            base.Update();

            if (_fsm.CurrentState.GetType() == typeof(RagdollState))
            {
                _getUpTimer -= Time.deltaTime;

                if (_getUpTimer <= 0)
                {
                    _fsm.CurrentState.Exit();
                    _getUpTimer = _getUpDelay;
                }
            }
        }
    }
}