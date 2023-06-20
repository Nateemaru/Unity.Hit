using Zenject;

namespace _Scripts.Services.GameStateMachine.GameStates
{
    public class GamePauseState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GamePauseState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, GamePauseState>
        {
        }
    }
}