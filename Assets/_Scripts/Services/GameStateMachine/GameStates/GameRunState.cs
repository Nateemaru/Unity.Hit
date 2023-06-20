using Zenject;

namespace _Scripts.Services.GameStateMachine.GameStates
{
    public class GameRunState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameRunState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, GameRunState>
        {
        }
    }
}