using _Scripts.Gameplay;
using _Scripts.Services.StateMachines.GameStateMachine.GameStates;
using Zenject;

namespace _Scripts.Services.StateMachines.LevelStateMachine.LevelStates
{
    public class LevelInitState : IState
    {
        private readonly ILevelStateMachine _levelStateMachine;
        private readonly LevelSpawner _levelSpawner;
        private readonly CameraHasher _cameraHasher;

        public LevelInitState(ILevelStateMachine levelStateMachine, LevelSpawner levelSpawner, CameraHasher cameraHasher)
        {
            _levelStateMachine = levelStateMachine;
            _levelSpawner = levelSpawner;
            _cameraHasher = cameraHasher;
        }

        public void Enter()
        {
            _levelSpawner.CreateLevel();
            _cameraHasher.Cache();
            _levelStateMachine.ChangeState<LevelRunState>();
        }

        public class Factory : PlaceholderFactory<IStateMachine, LevelInitState>
        {
        }
    }
}