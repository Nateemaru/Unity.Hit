using _Scripts.Services.InputService;
using Zenject;

namespace _Scripts.Services.StateMachines.LevelStateMachine.LevelStates
{
    public class LevelStartState : IState
    {
        private readonly ILevelStateMachine _levelStateMachine;
        private readonly IInputService _inputService;

        public LevelStartState(ILevelStateMachine levelStateMachine, IInputService inputService)
        {
            _levelStateMachine = levelStateMachine;
            _inputService = inputService;

            _inputService.OnTouched += () => _levelStateMachine.ChangeState<LevelRunState>();
        }
        
        public class Factory : PlaceholderFactory<IStateMachine, LevelStartState>
        {
        }
    }
}