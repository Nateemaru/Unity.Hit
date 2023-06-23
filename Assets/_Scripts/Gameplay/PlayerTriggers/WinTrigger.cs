using _Scripts.Player;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using _Scripts.Services.GameStateMachine;
using _Scripts.Services.GameStateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.PlayerTriggers
{
    public class WinTrigger : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out MovementBase movementBase))
                _gameStateMachine.ChangeState<GameWinState>();
        }
    }
}