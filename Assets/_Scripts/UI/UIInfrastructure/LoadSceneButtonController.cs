using _Scripts.Services.GameStateMachine;
using _Scripts.Services.GameStateMachine.GameStates;
using _Scripts.UI.UIInfrastructure.BaseComponents;

namespace _Scripts.UI.UIInfrastructure
{
    public class LoadSceneButtonController : BaseViewController
    {
        private readonly IGameStateMachine _gameStateMachine;

        public LoadSceneButtonController(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public void OnButtonClicked()
        {
            _gameStateMachine.ChangeState<SceneLoadState>();
        }
    }
}