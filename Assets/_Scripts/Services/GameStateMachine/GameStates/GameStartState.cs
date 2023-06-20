using _Scripts.Gameplay;
using UnityEngine;
using Zenject;

namespace _Scripts.Services.GameStateMachine.GameStates
{
    public class GameStartState : IGameState
    {
        private readonly LevelSpawner _levelSpawner;
        private readonly IGameStateMachine _gameStateMachine;

        public GameStartState(LevelSpawner levelSpawner, IGameStateMachine gameStateMachine)
        {
            _levelSpawner = levelSpawner;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _levelSpawner.CreateLevel();
            _gameStateMachine.ChangeState<GameRunState>();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GameStartState>
        {
        }
    }
}