

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Services.CoroutineRunnerService;
using _Scripts.Services.Database;
using _Scripts.SO;
using _Scripts.UI;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace _Scripts.Services.StateMachines.GameStateMachine.GameStates
{
    public class GameStartState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private ProgressBarController _progressBarController;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly LevelsContainerConfig _levelsContainerConfig;
        private readonly IDataReader _dataReader;

        public GameStartState(
            IGameStateMachine gameStateMachine,
            ProgressBarController progressBarController,
            ICoroutineRunner coroutineRunner,
            LevelsContainerConfig levelsContainerConfig,
            IDataReader dataReader)
        {
            _gameStateMachine = gameStateMachine;
            _progressBarController = progressBarController;
            _coroutineRunner = coroutineRunner;
            _levelsContainerConfig = levelsContainerConfig;
            _dataReader = dataReader;
        }

        public void Enter()
        {
            var levels = _dataReader.GetArrayData<Level>(GlobalConstants.LEVELS);

            if (levels.IsNullOrEmpty())
            {
                _dataReader.SaveArrayData(GlobalConstants.LEVELS, _levelsContainerConfig.Levels);
                var lastLevel = _levelsContainerConfig.Levels.First(item => !item.IsCompleted);
                _dataReader.SaveData(GlobalConstants.LAST_LEVEL, lastLevel);
            }

            _coroutineRunner.StartCoroutine(StartGameCoroutine());
        }

        private IEnumerator StartGameCoroutine()
        {
            while (!_progressBarController.IsDone)
            {
                _progressBarController.UpdateProgressBar();
                yield return null;
            }
            
            _gameStateMachine.ChangeState<GameLoadState>();
        }

        public class Factory : PlaceholderFactory<IStateMachine, GameStartState>
        {
        }
    }
}