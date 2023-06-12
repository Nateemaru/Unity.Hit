using Animancer;

namespace _Scripts.Gameplay.FSM.States
{
    public class IdleState : StateBase
    {
        private AnimancerComponent _animancer;
        private AnimancerTransition _actionClip;

        public IdleState(AnimancerComponent animancer, AnimancerTransition actionClip)
        {
            _animancer = animancer;
            _actionClip = actionClip;
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