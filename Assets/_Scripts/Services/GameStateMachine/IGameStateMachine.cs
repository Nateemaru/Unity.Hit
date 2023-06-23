using System;
using _Scripts.Services.GameStateMachine.GameStates;

namespace _Scripts.Services.GameStateMachine
{
    public interface IGameStateMachine
    {
        public delegate void OnGameStateChanged(IGameState gameState);
        
        public OnGameStateChanged OnStateChanged { get; set; }
        
        public void ChangeState<TState>() where TState : class, IGameState;
    }
}