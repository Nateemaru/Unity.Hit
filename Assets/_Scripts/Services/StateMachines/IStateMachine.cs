namespace _Scripts.Services.StateMachines
{
    public interface IStateMachine
    {
        public delegate void StateChanged(IState state);
        
        public StateChanged OnStateChanged { get; set; }
        
        public void ChangeState<TState>() where TState : class, IState;
    }
}