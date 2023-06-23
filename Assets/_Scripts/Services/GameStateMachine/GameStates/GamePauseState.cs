using _Scripts.Services.AudioSystem;
using _Scripts.Services.Database;
using _Scripts.Services.PauseHandlerService;
using Zenject;

namespace _Scripts.Services.GameStateMachine.GameStates
{
    public class GamePauseState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly PauseHandler _pauseHandler;
        private readonly AudioController _audioController;

        public GamePauseState(IGameStateMachine gameStateMachine, PauseHandler pauseHandler, AudioController audioController)
        {
            _gameStateMachine = gameStateMachine;
            _pauseHandler = pauseHandler;
            _audioController = audioController;
        }

        public void Enter()
        {
            _pauseHandler.SetPause(true);
            _audioController.SwitchSnapshot(GlobalConstants.PAUSE_SNAPSHOT);
        }

        public void Exit()
        {
            _pauseHandler.SetPause(false);
            _audioController.SwitchSnapshot(GlobalConstants.RUNNING_SNAPSHOT);
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GamePauseState>
        {
        }
    }
}