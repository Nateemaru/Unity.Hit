using _Scripts.Services.Database;
using _Scripts.Services.InputService;
using _Scripts.Services.SceneLoadService;
using _Scripts.UI;
using Zenject;

namespace _Scripts.Services.StateMachines.GameStateMachine.GameStates
{
    public class GameLoadState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoadService _sceneLoadService;
        private readonly IFadeScreen _fadeScreen;
        private readonly IInputService _inputService;

        public GameLoadState(
            IGameStateMachine gameStateMachine,
            ISceneLoadService sceneLoadService,
            IFadeScreen fadeScreen,
            IInputService inputService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoadService = sceneLoadService;
            _fadeScreen = fadeScreen;
            _inputService = inputService;
        }
        
        public void Enter()
        {
            _inputService.Reset();
            
            _fadeScreen.FadeIn(() =>
            {
                _sceneLoadService.Load(GlobalConstants.GAME_SCENE_KEY, () =>
                {
                    _fadeScreen.FadeOut();
                    _gameStateMachine.ChangeState<GameRunState>();
                });
            });
        }

        public class Factory : PlaceholderFactory<IStateMachine, GameLoadState>
        {
        }
    }
}