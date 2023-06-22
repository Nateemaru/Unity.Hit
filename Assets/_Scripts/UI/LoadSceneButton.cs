using _Scripts.Services.GameStateMachine;
using _Scripts.Services.GameStateMachine.GameStates;
using Zenject;

namespace _Scripts.UI
{
    public class LoadSceneButton : ButtonBase
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        protected override void OnClick()
        {
            _gameStateMachine.ChangeState<SceneLoadState>();
        }
    }
}