using _Scripts.Services.AudioSystem;
using _Scripts.Services.Database;
using _Scripts.Services.PauseHandlerService;
using Zenject;

namespace _Scripts.Services.StateMachines.LevelStateMachine.LevelStates
{
    public class LevelPauseState : IState
    {
        private readonly ILevelStateMachine _levelStateMachine;
        private readonly PauseHandler _pauseHandler;
        private readonly AudioController _audioController;

        public LevelPauseState(ILevelStateMachine levelStateMachine, PauseHandler pauseHandler, AudioController audioController)
        {
            _levelStateMachine = levelStateMachine;
            _pauseHandler = pauseHandler;
            _audioController = audioController;
        }

        public void Enter()
        {
            _pauseHandler.SetPause(true);
            _audioController.SwitchSnapshot(GlobalConstants.PAUSE_SNAPSHOT_KEY);
        }

        public void Exit()
        {
            _pauseHandler.SetPause(false);
            _audioController.SwitchSnapshot(GlobalConstants.RUNNING_SNAPSHOT_KEY);
        }

        public class Factory : PlaceholderFactory<IStateMachine, LevelPauseState>
        {
        }
    }
}