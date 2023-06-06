using _Scripts.Gameplay.FSM;
using _Scripts.Services;
using _Scripts.SO;
using Animancer;
using UnityEngine;

namespace _Scripts.Gameplay.States
{
    public class ShootState : StateBase
    {
        private AnimancerComponent _animancer;
        private AnimancerTransition _actionClip;
        private LayerMask _targetMask;
        private float _shootingDelay;
        private VfxConfig _vFXConfig;

        private float _shootingTimer;

        public ShootState(AnimancerComponent animancer, AnimancerTransition actionClip
            , LayerMask targetMask, float shootingDelay, VfxConfig vfxConfig)
        {
            _animancer = animancer;
            _actionClip = actionClip;
            _targetMask = targetMask;
            _shootingDelay = shootingDelay;
            _vFXConfig = vfxConfig;
        }

        public override void Enter()
        {
            AnimancerState state = _animancer.Play(_actionClip);
            _isAnimationEnded = true;
        }

        public override void Update()
        {
            _shootingTimer -= Time.deltaTime;
            
            var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (_shootingTimer <= 0 && Physics.Raycast(ray, out var hit, _targetMask))
            {
                var bulletDecal = PoolHub.Instance.GetObject(_vFXConfig);
                bulletDecal.transform.position = hit.point;
                _shootingTimer = _shootingDelay;
            }
        }

        public override void Exit()
        {
        }
    }
}