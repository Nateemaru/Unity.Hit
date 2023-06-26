using System.Collections;
using _Scripts.Gameplay;
using _Scripts.Services.CoroutineRunnerService;
using _Scripts.Services.StateMachines.LevelStateMachine.LevelStates;
using _Scripts.UI;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using Zenject;

namespace _Scripts.Services.StateMachines.GameStateMachine.GameStates
{
    public class GameStartState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private ProgressBarController _progressBarController;
        private IFadeScreen _fadeScreen;
        private readonly ICoroutineRunner _coroutineRunner;

        public GameStartState(
            IGameStateMachine gameStateMachine,
            ProgressBarController progressBarController, 
            IFadeScreen fadeScreen,
            ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _progressBarController = progressBarController;
            _fadeScreen = fadeScreen;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            _coroutineRunner.StartCoroutine(StartGameCoroutine());
        }

        private IEnumerator StartGameCoroutine()
        {
            while (!_progressBarController.IsDone)
            {
                _progressBarController.UpdateProgressBar();
                yield return null;
            }
            
            _gameStateMachine.ChangeState<GameLoadState>();
        }

        public class Factory : PlaceholderFactory<IStateMachine, GameStartState>
        {
        }
    }
}