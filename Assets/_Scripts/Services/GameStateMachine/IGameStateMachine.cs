using _Scripts.Services.GameStateMachine.GameStates;

namespace _Scripts.Services.GameStateMachine
{
    public interface IGameStateMachine
    {
        public void ChangeState<TState>() where TState : class, IGameState;
    }
}