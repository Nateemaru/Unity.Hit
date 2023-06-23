using System;
using System.Collections.Generic;
using _Scripts.Services.GameStateMachine.GameStates;

namespace _Scripts.Services.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IGameState> _registeredStates;
        private IGameState _currentGameState;

        public IGameStateMachine.OnGameStateChanged OnStateChanged { get; set; }
        
        public IGameState CurrentGameState => _currentGameState;

        public GameStateMachine(
            GameStartState.Factory gameStartStateFactory,
            GameRunState.Factory gameRunStateFactory,
            GamePauseState.Factory gamePauseStateFactory,
            GameLoseState.Factory gameLoseStateFactory,
            GameWinState.Factory gameWinStateFactory, 
            SceneLoadState.Factory sceneLoadStateFactory)
        {
            _registeredStates = new Dictionary<Type, IGameState>();
            
            RegisterState(gameStartStateFactory.Create(this));
            RegisterState(gameRunStateFactory.Create(this));
            RegisterState(gamePauseStateFactory.Create(this));
            RegisterState(gameLoseStateFactory.Create(this));
            RegisterState(gameWinStateFactory.Create(this));
            RegisterState(sceneLoadStateFactory.Create(this));
        }

        private void RegisterState<TState>(TState state) where TState : IGameState =>
            _registeredStates.Add(typeof(TState), state);

        public void ChangeState<TState>() where TState : class, IGameState
        {
            _currentGameState?.Exit();
      
            TState state = GetState<TState>();
            _currentGameState = state;
            
            _currentGameState.Enter();
            OnStateChanged?.Invoke(_currentGameState);
        }
    
        private TState GetState<TState>() where TState : class, IGameState => 
            _registeredStates[typeof(TState)] as TState;
    }
}