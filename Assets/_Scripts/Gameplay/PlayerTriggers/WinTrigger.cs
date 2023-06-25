using _Scripts.Player;
using _Scripts.Services.StateMachines;
using _Scripts.Services.StateMachines.GameStateMachine.GameStates;
using _Scripts.Services.StateMachines.LevelStateMachine;
using _Scripts.Services.StateMachines.LevelStateMachine.LevelStates;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.PlayerTriggers
{
    public class WinTrigger : MonoBehaviour
    {
        private ILevelStateMachine _levelStateMachine;

        [Inject]
        private void Construct(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out MovementBase movementBase))
                _levelStateMachine.ChangeState<LevelWinState>();
        }
    }
}