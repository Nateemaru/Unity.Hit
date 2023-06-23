using System;
using _Scripts.Services.GameStateMachine;
using _Scripts.Services.GameStateMachine.GameStates;
using _Scripts.UI.UIInfrastructure.BaseComponents;

namespace _Scripts.UI.UIInfrastructure
{
    public class LoseScreenController : BaseViewController
    {
        private readonly IGameStateMachine _gameStateMachine;

        public Action ShowCommand;

        public LoseScreenController(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;

            _gameStateMachine.OnStateChanged += GetGameState;
        }

        private void GetGameState(IGameState gameState)
        {
            if (gameState.GetType() == typeof(GameLoseState))
                ShowCommand?.Invoke();
        }
        
    }
}