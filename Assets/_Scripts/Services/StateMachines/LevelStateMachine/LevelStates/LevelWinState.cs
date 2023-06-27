using System.Linq;
using _Scripts.Services.Database;
using _Scripts.SO;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace _Scripts.Services.StateMachines.LevelStateMachine.LevelStates
{
    public class LevelWinState : IState
    {
        private readonly ILevelStateMachine _levelStateMachine;
        private readonly IDataReader _dataReader;

        public LevelWinState(ILevelStateMachine levelStateMachine, IDataReader dataReader)
        {
            _levelStateMachine = levelStateMachine;
            _dataReader = dataReader;
        }

        public void Enter()
        {
            var lastLevel = _dataReader.GetData<Level>(GlobalConstants.LAST_LEVEL);
            var allLevels = _dataReader.GetArrayData<Level>(GlobalConstants.LEVELS);
            
            allLevels.FirstOrDefault(item => item.ID == lastLevel.ID)?.Complete();
            
            _dataReader.SaveArrayData(GlobalConstants.LEVELS, allLevels);
            var newLevel = allLevels.FirstOrDefault(item => !item.IsCompleted);

            if (newLevel == null)
                newLevel = allLevels.FirstOrDefault(item => item.ID != lastLevel.ID);
            
            _dataReader.SaveData(GlobalConstants.LAST_LEVEL, newLevel);
        }

        public class Factory : PlaceholderFactory<IStateMachine, LevelWinState>
        {
        }
    }
}