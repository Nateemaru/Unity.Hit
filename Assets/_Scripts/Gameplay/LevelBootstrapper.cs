using _Scripts.Services.StateMachines;
using _Scripts.Services.StateMachines.GameStateMachine.GameStates;
using _Scripts.Services.StateMachines.LevelStateMachine;
using _Scripts.Services.StateMachines.LevelStateMachine.LevelStates;
using Zenject;

namespace _Scripts.Gameplay
{
    public class LevelBootstrapper : IInitializable
    {
        private ILevelStateMachine _levelStateMachine;

        public LevelBootstrapper(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public void Initialize()
        {
            _levelStateMachine.ChangeState<LevelInitState>();
        }
    }
}