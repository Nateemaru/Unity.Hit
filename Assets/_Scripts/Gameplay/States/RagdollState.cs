using System.Collections;
using _Scripts.CodeSugar;
using _Scripts.Gameplay.FSM;
using _Scripts.Player;
using _Scripts.Services;
using Animancer;
using RootMotion.Dynamics;
using UnityEngine;

namespace _Scripts.Gameplay.States
{
    public class RagdollState : StateBase
    {
        private readonly AnimancerComponent _animancerComponent;
        private readonly PuppetMaster _puppetMaster;
        private readonly float _pinWeightDelta = 0.4f;

        public RagdollState(AnimancerComponent animancerComponent, PuppetMaster puppetMaster)
        {
            _animancerComponent = animancerComponent;
            _puppetMaster = puppetMaster;
        }
        
        public override void Enter()
        {
            _animancerComponent.Stop();
            _puppetMaster.Kill();
            _isAnimationEnded = true;
        }

        public override void Update()
        {
            _puppetMaster.pinWeight += _pinWeightDelta * Time.deltaTime;
        }

        public override void Exit()
        {
            _puppetMaster.pinWeight = 1f;
            _puppetMaster.Resurrect();
        }
    }
}