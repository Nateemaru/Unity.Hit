using System;
using Cinemachine;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Scripts.Services
{
    public class CamerasHasher : MonoBehaviour
    {
        private CinemachineBrain _brain;
        private CinemachineVirtualCamera[] _vcams;
        private CinemachineVirtualCamera _activeCamera =>  _brain.ActiveVirtualCamera as CinemachineVirtualCamera ?? _vcams[0];

        public CinemachineVirtualCamera ActiveCamera => _activeCamera;

        private void Start()
        {
            _brain = Object.FindObjectOfType<CinemachineBrain>();
            _vcams = Object.FindObjectsOfType<CinemachineVirtualCamera>();
        }
    }
}