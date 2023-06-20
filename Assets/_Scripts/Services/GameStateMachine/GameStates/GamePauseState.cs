using _Scripts.Services.PauseHandlerService;
using Zenject;

namespace _Scripts.Services.GameStateMachine.GameStates
{
    public class GamePauseState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly PauseHandler _pauseHandler;

        public GamePauseState(IGameStateMachine gameStateMachine, PauseHandler pauseHandler)
        {
            _gameStateMachine = gameStateMachine;
            _pauseHandler = pauseHandler;
        }

        public void Enter()
        {
            _pauseHandler.SetPause(true);
        }

        public void Exit()
        {
            _pauseHandler.SetPause(false);
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GamePauseState>
        {
        }
    }
}