using System;
using _Scripts.Services;
using _Scripts.UI.UIInfrastructure.BaseComponents;

namespace _Scripts.UI.UIInfrastructure.ViewControllers
{
    public class LevelProgressController : BaseViewController
    {
        private readonly EnemiesHasher _enemiesHasher;

        public Action OnLevelProgressChanged;

        public LevelProgressController(EnemiesHasher enemiesHasher)
        {
            _enemiesHasher = enemiesHasher;
            _enemiesHasher.OnEnemiesAmountChanged += () => OnLevelProgressChanged?.Invoke();
        }

        public float GetLevelCompletePercent(float maxValue)
        {
            return maxValue - (_enemiesHasher.Enemies.Count / _enemiesHasher.TotalEnemies);
        }
    }
}