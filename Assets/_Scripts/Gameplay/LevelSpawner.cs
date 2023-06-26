using _Scripts.Factories;
using _Scripts.SO;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay
{
    public class LevelSpawner
    {
        private LevelsContainerConfig _levelsContainer;
        private readonly GameObjectFactory _factory;
        private LevelsContainerConfig.Level _currentLevel;

        public LevelSpawner(LevelsContainerConfig levelsContainer, GameObjectFactory factory)
        {
            _levelsContainer = levelsContainer;
            _factory = factory;
        }

        public void CreateLevel()
        {
            LevelsContainerConfig.Level newLevel;
            
            for (int i = 0; i < _levelsContainer.Levels.Length; i++)
            {
                newLevel = _levelsContainer.Levels[Random.Range(0, _levelsContainer.Levels.Length - 1)];

                if (newLevel != _currentLevel)
                {
                    _currentLevel = newLevel;
                    break;
                }
            }

            _factory.CreateGameObject(_currentLevel.Prefab);
        }
    }
}