using _Scripts.CodeSugar;
using _Scripts.Gameplay.FSM;
using Animancer;
using UnityEngine;

namespace _Scripts.Gameplay.States
{
    public class EnemyMoveState : StateBase
    {
        private Transform _origin;
        private AnimancerComponent _animancer;
        private AnimancerTransition _actionClip;
        private float _speed;
        private Transform _target;
        
        public EnemyMoveState(Transform origin, AnimancerComponent animancer,
            AnimancerTransition actionClip, float speed, Transform target)
        {
            _origin = origin;
            _animancer = animancer;
            _actionClip = actionClip;
            _speed = speed;
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
                var dir = _target.position - _origin.position;
                dir.y = _origin.transform.position.y;

                _origin.position += dir * (_speed * Time.deltaTime);
                
                _origin.LookAtOnlyY(_target);
            }
        }

        public override void Exit()
        {
        }
    }
}