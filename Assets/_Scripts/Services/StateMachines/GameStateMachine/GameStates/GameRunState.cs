using Zenject;

namespace _Scripts.Services.StateMachines.GameStateMachine.GameStates
{
    public class GameRunState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameRunState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public class Factory : PlaceholderFactory<IStateMachine, GameRunState>
        {
        }
    }
}