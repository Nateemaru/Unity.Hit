using System.Collections;
using _Scripts.CodeSugar;
using _Scripts.Gameplay.FSM;
using _Scripts.Player;
using Animancer;
using RootMotion.Dynamics;
using UnityEngine;

namespace _Scripts.Gameplay.States
{
    public class RagdollState : StateBase
    {
        private readonly Transform _origin;
        private readonly AnimancerComponent _animancerComponent;
        private readonly PuppetMaster _puppetMaster;
        private readonly ITarget _target;

        public RagdollState(Transform origin, AnimancerComponent animancerComponent,
            PuppetMaster puppetMaster, ITarget target)
        {
            _origin = origin;
            _animancerComponent = animancerComponent;
            _puppetMaster = puppetMaster;
            _target = target;
        }
        
        public override void Enter()
        {
            _animancerComponent.Stop();
            _puppetMaster.state = PuppetMaster.State.Dead;
            _isAnimationEnded = false;
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
            _puppetMaster.targetRoot.LookAtOnlyY(_origin.position - _target.GetTarget().position);
            _puppetMaster.state = PuppetMaster.State.Alive;
            _isAnimationEnded = true;
        }
    }
}