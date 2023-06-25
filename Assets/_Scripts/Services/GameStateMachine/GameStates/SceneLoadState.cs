using _Scripts.Services.PauseHandlerService;
using _Scripts.Services.SceneLoadService;
using Zenject;

namespace _Scripts.Services.GameStateMachine.GameStates
{
    public class SceneLoadState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoadService _sceneLoadService;

        public SceneLoadState(IGameStateMachine gameStateMachine, ISceneLoadService sceneLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoadService = sceneLoadService;
        }
        
        public void Enter()
        {
            // Fade in screen using custom "Fader" or asset "Easy Transition" async;
            //_sceneLoadService.Load("GameScene", _gameStateMachine.ChangeState<GameStartState>());
            _sceneLoadService.Load("GameScene");
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, SceneLoadState>
        {
        }
    }
}