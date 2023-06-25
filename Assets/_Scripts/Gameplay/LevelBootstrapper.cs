using _Scripts.Services.GameStateMachine;
using _Scripts.Services.GameStateMachine.GameStates;
using Zenject;

namespace _Scripts.Gameplay
{
    public class LevelBootstrapper : IInitializable
    {
        private IGameStateMachine _gameStateMachine;

        public LevelBootstrapper(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Initialize()
        {
            _gameStateMachine.ChangeState<GameStartState>();
        }
    }
}