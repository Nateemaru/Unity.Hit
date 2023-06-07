using _Scripts.Gameplay.FSM;
using _Scripts.Services;
using _Scripts.SO;
using Animancer;
using DG.Tweening;
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
        private Transform _firePoint;
        private VfxConfig _gunFireVfx;

        private float _shootingTimer;

        public ShootState(AnimancerComponent animancer, AnimancerTransition actionClip
            , LayerMask targetMask, float shootingDelay, VfxConfig vfxConfig, Transform firePoint, VfxConfig gunFireVfx)
        {
            _animancer = animancer;
            _actionClip = actionClip;
            _targetMask = targetMask;
            _shootingDelay = shootingDelay;
            _vFXConfig = vfxConfig;
            _firePoint = firePoint;
            _gunFireVfx = gunFireVfx;
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
            if (_shootingTimer <= 0 && Physics.Raycast(ray, out var hit, Mathf.Infinity, _targetMask))
            {
                var gunFire = PoolHub.Instance.GetObject(_gunFireVfx).transform.position = _firePoint.position;
                var bulletDecal = PoolHub.Instance.GetObject(_vFXConfig);
                bulletDecal.transform.position = hit.point;
                _shootingTimer = _shootingDelay;

                var enemy = hit.transform.root.GetComponent<HealthComponent>();

                if(enemy != null)
                    enemy.ApplyDamage(1);

                if (hit.transform.TryGetComponent(out Rigidbody rb))
                {
                    rb.AddForce(new Vector3(ray.direction.x, 2, ray.direction.z).normalized * 50, ForceMode.Impulse);
                }
            }
        }

        public override void Exit()
        {
        }
    }
}