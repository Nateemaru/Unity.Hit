using System;
using _Scripts.Services.StateMachines;
using _Scripts.Services.StateMachines.LevelStateMachine;
using _Scripts.Services.StateMachines.LevelStateMachine.LevelStates;
using _Scripts.UI.UIInfrastructure.BaseComponents;

namespace _Scripts.UI.UIInfrastructure.ViewControllers
{
    public class LoseScreenController : BaseViewController
    {
        private readonly ILevelStateMachine _levelStateMachine;

        public Action ShowCommand;

        public LoseScreenController(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;

            _levelStateMachine.OnStateChanged += GetGameState;
        }

        private void GetGameState(IState gameState)
        {
            if (gameState.GetType() == typeof(LevelLoseState))
                ShowCommand?.Invoke();
        }
        
    }
}