using Zenject;

namespace _Scripts.Services.StateMachines.LevelStateMachine.LevelStates
{
    public class LevelRunState : IState
    {
        private readonly ILevelStateMachine _levelStateMachine;
        private readonly EnemiesHasher _enemiesHasher;

        public LevelRunState(ILevelStateMachine levelStateMachine, EnemiesHasher enemiesHasher)
        {
            _levelStateMachine = levelStateMachine;
            _enemiesHasher = enemiesHasher;
        }

        public void Enter()
        {
            for (int i = 0; i < _enemiesHasher.Enemies.Count; i++)
                _enemiesHasher.Enemies[i]?.Provoke();
        }

        public class Factory : PlaceholderFactory<IStateMachine, LevelRunState>
        {
        }
    }
}