using System;
using _Scripts.Services.StateMachines;
using _Scripts.Services.StateMachines.GameStateMachine.GameStates;
using _Scripts.Services.StateMachines.LevelStateMachine;
using _Scripts.Services.StateMachines.LevelStateMachine.LevelStates;
using _Scripts.UI.UIInfrastructure.BaseComponents;

namespace _Scripts.UI.UIInfrastructure
{
    public class WinScreenController : BaseViewController
    {
        private readonly ILevelStateMachine _levelStateMachine;

        public Action ShowCommand;

        public WinScreenController(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;

            _levelStateMachine.OnStateChanged += GetGameState;
        }

        private void GetGameState(IState gameState)
        {
            if (gameState.GetType() == typeof(LevelWinState))
                ShowCommand?.Invoke();
        }
    }
}