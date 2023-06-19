using _Scripts.CodeSugar;
using _Scripts.Player;
using Animancer;
using UnityEngine;

namespace _Scripts.AI.FSM.States
{
    public class EnemyMoveState : StateBase
    {
        private readonly Transform _origin;
        private readonly AnimancerComponent _animancer;
        private readonly AnimancerTransition _actionClip;
        private readonly ITarget _target;
        private readonly float _speed;

        private float _rotSmooth = 3f;

        public EnemyMoveState(Transform origin, AnimancerComponent animancer,
            AnimancerTransition actionClip, ITarget target, float speed)
        {
            _origin = origin;
            _animancer = animancer;
            _actionClip = actionClip;
            _target = target;
            _speed = speed;
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
                var dir = _target.GetTarget().position;
                dir.y = _origin.transform.position.y;
                
                _origin.transform.position = 
                    Vector3.MoveTowards(_origin.transform.position, dir, (_speed * Time.deltaTime));
                _origin.LookAtOnlyYSmooth(_target.GetTarget(), _rotSmooth);
            }
        }

        public override void Exit()
        {
        }
    }
}