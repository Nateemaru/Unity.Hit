using _Scripts.Services.Database;
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
        }

        public class Factory : PlaceholderFactory<IStateMachine, LevelWinState>
        {
        }
    }
}