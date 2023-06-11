using _Scripts.Gameplay.FSM;
using _Scripts.Player;
using Animancer;
using UnityEngine;

namespace _Scripts.Gameplay.States
{
    public class HumanoidAttackState : StateBase
    {
        private readonly Transform _origin;
        private readonly AnimancerComponent _animancer;
        private readonly AnimancerTransition _actionClip;
        private readonly ITarget _target;

        public HumanoidAttackState(Transform origin, AnimancerComponent animancer, AnimancerTransition actionClip, ITarget target)
        {
            _origin = origin;
            _animancer = animancer;
            _actionClip = actionClip;
            _target = target;
        }
        
        public override void Enter()
        {
            AnimancerState state = _animancer.Play(_actionClip);
            _isAnimationEnded = true;
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }
}