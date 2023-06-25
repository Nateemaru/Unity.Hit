using Cinemachine;
using UnityEngine;
using Zenject;

namespace _Scripts.Services
{
    public class CameraHasher
    {
        private CinemachineBrain _brain;
        private CinemachineVirtualCamera[] _vcams;
        private CinemachineVirtualCamera _activeCamera =>  _brain.ActiveVirtualCamera as CinemachineVirtualCamera ?? _vcams[0];

        public CinemachineVirtualCamera ActiveCamera => _activeCamera;
        
        public void Cache()
        {
            _brain = Object.FindObjectOfType<CinemachineBrain>();
            _vcams = Object.FindObjectsOfType<CinemachineVirtualCamera>();
        }

        public void ClearCache()
        {
            _brain = null;
            _vcams = null;
        }
    }
}