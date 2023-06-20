using Zenject;

namespace _Scripts.Services.GameStateMachine.GameStates
{
    public class GameLoseState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameLoseState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, GameLoseState>
        {
        }
    }
}