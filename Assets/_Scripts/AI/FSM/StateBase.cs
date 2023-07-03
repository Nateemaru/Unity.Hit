namespace _Scripts.AI.FSM
{
    public abstract class StateBase
    {
        protected bool _isAnimationEnded;

        public bool IsAnimationEnded => _isAnimationEnded;

        public virtual void Enter()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void Exit()
        {
        }
    }
}
