using System.Collections;
using _Scripts.Services.StateMachines.GameStateMachine;
using _Scripts.Services.StateMachines.GameStateMachine.GameStates;
using _Scripts.UI;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Scripts.Gameplay
{
    public class GameStateMachineStarter : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;
        private GameStartState.Factory _gameStartStateFactory;
        private GameLoadState.Factory _gameLoadStateFactory;
        private GameRunState.Factory _gameRunStateFactory;

        [Inject]
        private void Construct(
            IGameStateMachine gameStateMachine,
            GameStartState.Factory gameStartStateFactory,
            GameLoadState.Factory gameLoadStateFactory,
            GameRunState.Factory gameRunStateFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameStartStateFactory = gameStartStateFactory;
            _gameLoadStateFactory = gameLoadStateFactory;
            _gameRunStateFactory = gameRunStateFactory;
        }

        private void Start()
        {
            _gameStateMachine.RegisterState(_gameStartStateFactory.Create(_gameStateMachine));
            _gameStateMachine.RegisterState(_gameLoadStateFactory.Create(_gameStateMachine));
            _gameStateMachine.RegisterState(_gameRunStateFactory.Create(_gameStateMachine));
            _gameStateMachine.ChangeState<GameStartState>();
        }
    }
}