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
        private readonly LevelsContainerConfig _levelsContainerConfig;
        private Level _currentLevel;

        public LevelSpawner(GameObjectFactory factory, IDataReader dataReader, LevelsContainerConfig levelsContainerConfig)
        {
            _factory = factory;
            _dataReader = dataReader;
            _levelsContainerConfig = levelsContainerConfig;
        }

        public void CreateLevel()
        {
            _currentLevel = _dataReader
                .GetData<Level>(GlobalConstants.LAST_LEVEL);
            
            _factory.CreateGameObject(_levelsContainerConfig
                                                        .Levels
                                                        .First(item => item.ID == _currentLevel.ID).Prefab);
        }
    }
}