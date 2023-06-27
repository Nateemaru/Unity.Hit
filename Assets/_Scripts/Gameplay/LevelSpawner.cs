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
        private Level _currentLevel;

        public LevelSpawner(GameObjectFactory factory, IDataReader dataReader)
        {
            _factory = factory;
            _dataReader = dataReader;
        }

        public void CreateLevel()
        {
            _currentLevel = _dataReader
                .GetData<Level>(GlobalConstants.LAST_LEVEL);
            
            _factory.CreateGameObject(_currentLevel.Prefab);
        }
    }
}