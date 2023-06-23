using System;
using _Scripts.CodeSugar;
using _Scripts.Services.GameStateMachine;
using _Scripts.Services.GameStateMachine.GameStates;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using UnityEngine;

namespace _Scripts.UI.UIInfrastructure
{
    public class WinScreenController : BaseViewController
    {
        private readonly IGameStateMachine _gameStateMachine;

        public Action ShowCommand;

        public WinScreenController(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;

            _gameStateMachine.OnStateChanged += GetGameState;
        }

        private void GetGameState(IGameState gameState)
        {
            if (gameState.GetType() == typeof(GameWinState))
                ShowCommand?.Invoke();
        }
    }
}