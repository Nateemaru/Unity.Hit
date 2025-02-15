using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Player;
using _Scripts.Services.CoroutineRunnerService;
using _Scripts.Services.Database;
using _Scripts.SO;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using Sirenix.Utilities;
using Zenject;

namespace _Scripts.Services.StateMachines.GameStateMachine.GameStates
{
    public class GameStartState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private ProgressBarController _progressBarController;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly GameConfig _gameConfig;
        private readonly IDataReader _dataReader;

        public GameStartState(
            IGameStateMachine gameStateMachine,
            ProgressBarController progressBarController,
            ICoroutineRunner coroutineRunner,
            GameConfig gameConfig,
            IDataReader dataReader)
        {
            _gameStateMachine = gameStateMachine;
            _progressBarController = progressBarController;
            _coroutineRunner = coroutineRunner;
            _gameConfig = gameConfig;
            _dataReader = dataReader;
        }

        public void Enter()
        {
            TryInitGameData();
            _coroutineRunner.StartCoroutine(StartGameCoroutine());
        }

        private void TryInitGameData()
        {
            var levelsFromJson = _dataReader.GetArrayData<Level>(GlobalConstants.LEVELS_KEY);
            var weaponDataFromJson = _dataReader.GetData<WeaponMetaData>(GlobalConstants.CURRENT_WEAPON_DATA_KEY);
            var weaponConfigContainerFromJson =
                _dataReader.GetArrayData<WeaponMetaData>(GlobalConstants.WEAPON_DATA_CONTAINER_KEY);

            if (levelsFromJson.IsNullOrEmpty() || levelsFromJson.Length != _gameConfig.LevelsContainerConfig.Levels.Length)
            {
                _dataReader.SaveArrayData(GlobalConstants.LEVELS_KEY, _gameConfig.LevelsContainerConfig.Levels);
                var lastLevel = _gameConfig.LevelsContainerConfig.Levels.First(item => !item.IsCompleted);
                _dataReader.SaveData(GlobalConstants.LAST_LEVEL_KEY, lastLevel);
            }

            if (weaponDataFromJson == null)
                _dataReader.SaveData(GlobalConstants.CURRENT_WEAPON_DATA_KEY, _gameConfig.DefaultWeapon.MetaData);

            if (weaponConfigContainerFromJson == null ||
                weaponConfigContainerFromJson.Length != _gameConfig.WeaponSkinContainer.WeaponConfigs.Length)
            {
                List<WeaponMetaData> weaponMetaData = new List<WeaponMetaData>();

                for (int i = 0; i < _gameConfig.WeaponSkinContainer.WeaponConfigs.Length; i++)
                    weaponMetaData.Add(_gameConfig.WeaponSkinContainer.WeaponConfigs[i].MetaData);
                
                _dataReader.SaveArrayData(GlobalConstants.WEAPON_DATA_CONTAINER_KEY, weaponMetaData.ToArray());
            }
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