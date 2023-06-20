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
        private GameObject _currentLevelPrefab;

        public LevelSpawner(LevelsContainerConfig levelsContainer, GameObjectFactory factory)
        {
            _levelsContainer = levelsContainer;
            _factory = factory;
        }

        public void CreateLevel()
        {
            GameObject newLevelPrefab;
            
            for (int i = 0; i < _levelsContainer.LevelPrefabs.Length; i++)
            {
                newLevelPrefab = _levelsContainer.LevelPrefabs[Random.Range(0, _levelsContainer.LevelPrefabs.Length - 1)];

                if (newLevelPrefab != _currentLevelPrefab)
                {
                    _currentLevelPrefab = newLevelPrefab;
                    break;
                }
            }

            _factory.CreateGameObject(_currentLevelPrefab);
        }
    }
}