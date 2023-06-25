using _Scripts.Gameplay;
using UnityEngine;
using Zenject;

namespace _Scripts.Services.GameStateMachine.GameStates
{
    public class GameStartState : IGameState
    {
        private readonly LevelSpawner _levelSpawner;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly CameraHasher _cameraHasher;

        public GameStartState(LevelSpawner levelSpawner, IGameStateMachine gameStateMachine, CameraHasher cameraHasher)
        {
            _levelSpawner = levelSpawner;
            _gameStateMachine = gameStateMachine;
            _cameraHasher = cameraHasher;
        }

        public void Enter()
        {
            _levelSpawner.CreateLevel();
            _cameraHasher.Cache();
            _gameStateMachine.ChangeState<GameRunState>();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GameStartState>
        {
        }
    }
}