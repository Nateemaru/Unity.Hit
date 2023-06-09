using _Scripts.Gameplay.FSM;
using Animancer;
using UnityEngine;

namespace _Scripts.Gameplay.States
{
    public class RagdollState : StateBase
    {
        private readonly Transform _origin;
        private readonly AnimancerComponent _animancerComponent;
        private readonly RagdollController _ragdoll;

        public RagdollState(Transform origin, AnimancerComponent animancerComponent, RagdollController ragdoll)
        {
            _origin = origin;
            _animancerComponent = animancerComponent;
            _ragdoll = ragdoll;
        }
        
        public override void Enter()
        {
            _animancerComponent.Animator.enabled = false;
            _ragdoll.EnableRagdoll();
            _isAnimationEnded = false;
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
            _ragdoll.AdjustRootTransform();
            _animancerComponent.Animator.enabled = true;
        }
    }
}