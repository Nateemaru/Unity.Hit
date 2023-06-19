namespace _Scripts.AI.FSM
{
    public abstract class StateBase
    {
        protected bool _isAnimationEnded;

        public bool IsAnimationEnded => _isAnimationEnded;
        
        public abstract void Enter();
    
        public abstract void Update();
    
        public abstract void Exit();
    }
}
