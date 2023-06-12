using _Scripts.Player;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using UnityEngine;

namespace _Scripts.Gameplay.PlayerTriggers
{
    public class JumpTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out MovementBase movementBase))
                EventBus.RaiseEvent<IPlayerJumpSubscriber>(item => item.OnPlayerJumped());
        }
    }
}