using System.Linq;
using _Scripts.Factories;
using _Scripts.Services.Database;
using _Scripts.SO;

namespace _Scripts.Gameplay
{
    public class LevelSpawner
    {
        private readonly GameObjectFactory _factory;
        private readonly IDataReader _dataReader;
        private readonly GameConfig _gameConfig;
        private Level _currentLevel;

        public LevelSpawner(GameObjectFactory factory, IDataReader dataReader, GameConfig gameConfig)
        {
            _factory = factory;
            _dataReader = dataReader;
            _gameConfig = gameConfig;
        }

        public void CreateLevel()
        {
            _currentLevel = _dataReader
                .GetData<Level>(GlobalConstants.LAST_LEVEL_KEY);
            
            _factory.CreateGameObject(_gameConfig
                                        .LevelsContainerConfig
                                        .Levels
                                        .First(item => item.ID == _currentLevel.ID).Prefab);
        }
    }
}