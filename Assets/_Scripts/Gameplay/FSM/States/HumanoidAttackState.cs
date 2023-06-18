using _Scripts.Player;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using Animancer;
using UnityEngine;

namespace _Scripts.Gameplay.FSM.States
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
            state.Events.Add(0.9f, () => EventBus.RaiseEvent<IGameLoseSubscriber>(item => item.OnGameLost()));
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