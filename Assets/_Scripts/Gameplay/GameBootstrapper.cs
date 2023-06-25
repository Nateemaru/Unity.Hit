using System.Collections;
using _Scripts.Services.StateMachines.GameStateMachine;
using _Scripts.Services.StateMachines.GameStateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            _gameStateMachine.ChangeState<GameStartState>();
        }
    }
}