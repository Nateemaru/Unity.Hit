using Zenject;

namespace _Scripts.Services.GameStateMachine.GameStates
{
    public class GameWinState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameWinState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GameWinState>
        {
        }
    }
}