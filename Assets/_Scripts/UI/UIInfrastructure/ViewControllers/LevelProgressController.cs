using System;
using _Scripts.Services;
using _Scripts.Services.Database;
using _Scripts.SO;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using Zenject;

namespace _Scripts.UI.UIInfrastructure.ViewControllers
{
    public class LevelProgressController : BaseViewController, IInitializable
    {
        private readonly EnemiesHasher _enemiesHasher;
        private readonly IDataReader _dataReader;
        private int _levelCounter;

        public Action OnLevelProgressChanged;
        public Action<string> OnLevelCounterChanged;

        public LevelProgressController(EnemiesHasher enemiesHasher, IDataReader dataReader)
        {
            _enemiesHasher = enemiesHasher;
            _dataReader = dataReader;
        }

        public void Initialize()
        {
            _enemiesHasher.OnEnemiesAmountChanged += () => OnLevelProgressChanged?.Invoke();

            var level = _dataReader.GetData<Level>(GlobalConstants.LAST_LEVEL_KEY);
            _levelCounter = level.ID;
            
            OnLevelCounterChanged?.Invoke(_levelCounter.ToString());
        }

        public float GetLevelCompletePercent(float maxValue)
        {
            return maxValue - (_enemiesHasher.Enemies.Count / _enemiesHasher.TotalEnemies);
        }
    }
}