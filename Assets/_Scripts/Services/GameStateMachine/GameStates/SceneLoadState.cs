using _Scripts.Services.PauseHandlerService;
using _Scripts.Services.SceneLoadService;
using _Scripts.UI;
using Zenject;

namespace _Scripts.Services.GameStateMachine.GameStates
{
    public class SceneLoadState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoadService _sceneLoadService;
        private readonly IFadeScreen _fadeScreen;

        public SceneLoadState(IGameStateMachine gameStateMachine, ISceneLoadService sceneLoadService, IFadeScreen fadeScreen)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoadService = sceneLoadService;
            _fadeScreen = fadeScreen;
        }
        
        public void Enter()
        {
            //_sceneLoadService.Load("GameScene", _gameStateMachine.ChangeState<GameStartState>());
            _fadeScreen.FadeIn(() =>
            {
                _sceneLoadService.Load("GameScene", () => _fadeScreen.FadeOut());
            });
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, SceneLoadState>
        {
        }
    }
}