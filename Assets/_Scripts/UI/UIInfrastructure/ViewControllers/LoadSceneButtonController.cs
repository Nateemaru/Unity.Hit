using _Scripts.Services.StateMachines.GameStateMachine;
using _Scripts.Services.StateMachines.GameStateMachine.GameStates;
using _Scripts.UI.UIInfrastructure.BaseComponents;

namespace _Scripts.UI.UIInfrastructure.ViewControllers
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
            _gameStateMachine.ChangeState<GameLoadState>();
        }
    }
}