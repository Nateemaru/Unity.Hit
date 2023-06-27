using System;
using _Scripts.Services;
using _Scripts.Services.Database;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using Zenject;

namespace _Scripts.UI.UIInfrastructure.ViewControllers
{
    public class LevelProgressController : BaseViewController, IInitializable
    {
        private readonly EnemiesHasher _enemiesHasher;
        private readonly IDataReader _dataReader;
        private string _levelCounter;

        public string LevelCounter => _levelCounter;

        public Action OnLevelProgressChanged;

        public LevelProgressController(EnemiesHasher enemiesHasher, IDataReader dataReader)
        {
            _enemiesHasher = enemiesHasher;
            _dataReader = dataReader;
        }

        public void Initialize()
        {
            _enemiesHasher.OnEnemiesAmountChanged += () => OnLevelProgressChanged?.Invoke();
        }

        public float GetLevelCompletePercent(float maxValue)
        {
            return maxValue - (_enemiesHasher.Enemies.Count / _enemiesHasher.TotalEnemies);
        }
    }
}