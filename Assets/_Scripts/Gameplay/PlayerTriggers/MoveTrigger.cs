using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Gameplay.PlayerTriggers
{
    public class MoveTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IRemoteControllable movingController))
            {
                movingController.Move();
            }
        }
    }
}