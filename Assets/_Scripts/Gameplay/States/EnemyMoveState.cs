using _Scripts.CodeSugar;
using _Scripts.Gameplay.FSM;
using _Scripts.Player;
using Animancer;
using RootMotion.Dynamics;
using UnityEngine;

namespace _Scripts.Gameplay.States
{
    public class EnemyMoveState : StateBase
    {
        private Transform _origin;
        private AnimancerComponent _animancer;
        private AnimancerTransition _actionClip;
        private readonly PuppetMaster _puppetMaster;
        private ITarget _target;
        
        public EnemyMoveState(Transform origin, AnimancerComponent animancer,
            AnimancerTransition actionClip, PuppetMaster puppetMaster, ITarget target)
        {
            _origin = origin;
            _animancer = animancer;
            _actionClip = actionClip;
            _puppetMaster = puppetMaster;
            _target = target;
        }
        
        public override void Enter()
        {
            AnimancerState state = _animancer.Play(_actionClip);
            _isAnimationEnded = true;
        }

        public override void Update()
        {
            if (_target != null)
            {
                _puppetMaster.targetRoot.LookAtOnlyY(_target.GetTarget());
                _origin.LookAtOnlyY(_target.GetTarget());
            }
        }

        public override void Exit()
        {
        }
    }
}