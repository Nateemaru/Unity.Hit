using System;
using System.Collections.Generic;
using _Scripts.Services.StateMachines.GameStateMachine.GameStates;

namespace _Scripts.Services.StateMachines.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IState> _registeredStates;
        private IState _currentGameState;

        public IStateMachine.StateChanged OnStateChanged { get; set; }
        
        public IState CurrentGameState => _currentGameState;

        public GameStateMachine(
            GameStartState.Factory gameStartStateFactory,
            GameLoadState.Factory sceneLoadStateFactory,
            GameRunState.Factory gameRunStateFactory)
        {
            _registeredStates = new Dictionary<Type, IState>();
            
            RegisterState(gameStartStateFactory.Create(this));
            RegisterState(sceneLoadStateFactory.Create(this));
            RegisterState(gameRunStateFactory.Create(this));
        }

        private void RegisterState<TState>(TState state) where TState : IState =>
            _registeredStates.Add(typeof(TState), state);

        public void ChangeState<TState>() where TState : class, IState
        {
            TState state = GetState<TState>();

            if (state != _currentGameState)
            {
                _currentGameState?.Exit();
                _currentGameState = state;
                _currentGameState.Enter();
                OnStateChanged?.Invoke(_currentGameState);
            }
        }
    
        private TState GetState<TState>() where TState : class, IState => 
            _registeredStates[typeof(TState)] as TState;
    }
}