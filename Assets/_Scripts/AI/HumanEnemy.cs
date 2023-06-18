using System;
using _Scripts.CodeSugar;
using _Scripts.Gameplay.FSM;
using _Scripts.Gameplay.FSM.States;
using Animancer;
using RootMotion.Dynamics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.AI
{
    public class HumanEnemy : EnemyBase
    {
        [TabGroup("Components")][SerializeField] private PuppetMaster _puppetMaster;
        [TabGroup("Animations")][SerializeField] private AnimancerTransition _idleClip;
        [TabGroup("Animations")][SerializeField] private AnimancerTransition _moveClip;
        [TabGroup("Animations")][SerializeField] private AnimancerTransition _attackClip;
        private float _maxPinWeight = 1;

        protected override void Init()
        {
            _health.OnHealthChanged += () => _puppetMaster.pinWeight = 0f;
            _health.OnDeadAction += () => _puppetMaster.Kill();
            
            var idleState = new IdleState(_animancer, _idleClip);
            var moveState = new EnemyMoveState(transform, _animancer, _moveClip, _target, _config.Speed);
            var ragdollState = new RagdollState(_animancer, _puppetMaster);
            var attackState = new HumanoidAttackState(transform, _animancer, _attackClip, _target);
            
            _fsm = new FSM();
            _fsm.SetState(idleState);
            
            _fsm.AddAnyTransition(ragdollState, () => _puppetMaster.pinWeight < _maxPinWeight);
            
            _fsm.AddAnyTransition(idleState, () => _isActive && _fsm.CurrentState.IsAnimationEnded);
            
            _fsm.AddAnyTransition(moveState, () => _target != null
                                                   && _fsm.CurrentState.IsAnimationEnded
                                                   && !transform.IsTargetNearby(_target.GetTarget(), _config.AttackDistance)
                                                   && transform.IsTargetNearby(_target.GetTarget(), 14)
                                                   && _puppetMaster.pinWeight >= _maxPinWeight);
            
            _fsm.AddAnyTransition(attackState, () => _target != null 
                                                     && transform.IsTargetNearby(_target.GetTarget(), _config.AttackDistance));
        }
    }
}