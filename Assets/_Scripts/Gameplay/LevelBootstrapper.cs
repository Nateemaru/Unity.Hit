using _Scripts.Services.GameStateMachine;
using _Scripts.Services.GameStateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay
{
    public class LevelBootstrapper
    {
        private IGameStateMachine _gameStateMachine;

        public LevelBootstrapper(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            gameStateMachine.ChangeState<GameStartState>();
        }
    }
}