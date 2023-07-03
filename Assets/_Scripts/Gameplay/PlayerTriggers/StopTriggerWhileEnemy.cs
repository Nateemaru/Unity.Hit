using _Scripts.Gameplay.Camera;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Gameplay.PlayerTriggers
{
    public class StopTriggerWhileEnemy : MonoBehaviour
    {
        [SerializeField] private TargetGroupContainer _targetGroupContainer;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IRemoteControllable movingController))
            {
                if(!_targetGroupContainer.IsEmpty)
                {
                    movingController.Stop();
                    _targetGroupContainer.OnContainerIsEmpty += () => movingController.Move();
                    return;
                }

                movingController.Move();
            }
            
        }
    }
}