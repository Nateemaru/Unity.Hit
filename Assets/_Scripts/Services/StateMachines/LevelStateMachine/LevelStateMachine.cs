using System;
using System.Collections.Generic;
using _Scripts.Services.StateMachines.GameStateMachine.GameStates;
using _Scripts.Services.StateMachines.LevelStateMachine.LevelStates;

namespace _Scripts.Services.StateMachines.LevelStateMachine
{
    public class LevelStateMachine : ILevelStateMachine
    {
        private Dictionary<Type, IState> _registeredStates;
        private IState _currentLevelState;

        public IStateMachine.StateChanged OnStateChanged { get; set; }
        
        public IState CurrentLevelState => _currentLevelState;

        public LevelStateMachine(
            LevelInitState.Factory levelInitStateFactory,
            LevelRunState.Factory levelRunStateFactory,
            LevelPauseState.Factory levelPauseStateFactory,
            LevelLoseState.Factory levelLoseStateFactory,
            LevelWinState.Factory levelWinStateFactory)
        {
            _registeredStates = new Dictionary<Type, IState>();
            
            RegisterState(levelInitStateFactory.Create(this));
            RegisterState(levelRunStateFactory.Create(this));
            RegisterState(levelPauseStateFactory.Create(this));
            RegisterState(levelLoseStateFactory.Create(this));
            RegisterState(levelWinStateFactory.Create(this));
        }

        private void RegisterState<TState>(TState state) where TState : IState =>
            _registeredStates.Add(typeof(TState), state);

        public void ChangeState<TState>() where TState : class, IState
        {
            TState state = GetState<TState>();

            if (state != _currentLevelState)
            {
                _currentLevelState?.Exit();
                _currentLevelState = state;
                _currentLevelState.Enter();
                OnStateChanged?.Invoke(_currentLevelState);
            }
        }
    
        private TState GetState<TState>() where TState : class, IState => 
            _registeredStates[typeof(TState)] as TState;
    }
}