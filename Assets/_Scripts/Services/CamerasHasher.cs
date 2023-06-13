using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using Cinemachine;
using UnityEngine;

namespace _Scripts.Services
{
    public class CamerasHasher
    {
        private CinemachineBrain _brain;
        private CinemachineVirtualCamera[] _vcams;
        private CinemachineVirtualCamera _activeCamera =>  _brain.ActiveVirtualCamera as CinemachineVirtualCamera ?? _vcams[0];

        public CinemachineVirtualCamera ActiveCamera => _activeCamera;

        public CamerasHasher()
        {
            _brain = Object.FindObjectOfType<CinemachineBrain>();
            _vcams = Object.FindObjectsOfType<CinemachineVirtualCamera>();
        }
    }
}