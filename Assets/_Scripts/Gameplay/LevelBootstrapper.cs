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
        private readonly LevelInitState.Factory _levelInitStateFactory;
        private readonly LevelRunState.Factory _levelRunStateFactory;
        private readonly LevelPauseState.Factory _levelPauseStateFactory;
        private readonly LevelLoseState.Factory _levelLoseStateFactory;
        private readonly LevelWinState.Factory _levelWinStateFactory;

        public LevelBootstrapper(
            ILevelStateMachine levelStateMachine,
            LevelInitState.Factory levelInitStateFactory,
            LevelRunState.Factory levelRunStateFactory,
            LevelPauseState.Factory levelPauseStateFactory,
            LevelLoseState.Factory levelLoseStateFactory,
            LevelWinState.Factory levelWinStateFactory)
        {
            _levelStateMachine = levelStateMachine;
            _levelInitStateFactory = levelInitStateFactory;
            _levelRunStateFactory = levelRunStateFactory;
            _levelPauseStateFactory = levelPauseStateFactory;
            _levelLoseStateFactory = levelLoseStateFactory;
            _levelWinStateFactory = levelWinStateFactory;
        }

        public void Initialize()
        {
            
            _levelStateMachine.RegisterState(_levelInitStateFactory.Create(_levelStateMachine));
            _levelStateMachine.RegisterState(_levelRunStateFactory.Create(_levelStateMachine));
            _levelStateMachine.RegisterState(_levelPauseStateFactory.Create(_levelStateMachine));
            _levelStateMachine.RegisterState(_levelLoseStateFactory.Create(_levelStateMachine));
            _levelStateMachine.RegisterState(_levelWinStateFactory.Create(_levelStateMachine));
            _levelStateMachine.ChangeState<LevelInitState>();
        }
    }
}