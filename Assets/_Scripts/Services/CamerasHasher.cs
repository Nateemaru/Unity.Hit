using Cinemachine;
using UnityEngine;
using Zenject;

namespace _Scripts.Services
{
    public class CamerasHasher : IInitializable
    {
        private CinemachineBrain _brain;
        private CinemachineVirtualCamera[] _vcams;
        private CinemachineVirtualCamera _activeCamera =>  _brain.ActiveVirtualCamera as CinemachineVirtualCamera ?? _vcams[0];

        public CinemachineVirtualCamera ActiveCamera => _activeCamera;
        
        public void Initialize()
        {
            _brain = Object.FindObjectOfType<CinemachineBrain>();
            _vcams = Object.FindObjectsOfType<CinemachineVirtualCamera>();
        }
    }
}