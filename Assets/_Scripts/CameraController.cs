using System;
using _Scripts.Services;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace _Scripts
{ 
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _mainCamera;
        private EnemiesHasher _enemiesHasher;

        [Inject]
        private void Construct(EnemiesHasher enemiesHasher)
        {
            _enemiesHasher = enemiesHasher;
        }

        private void Start()
        {
        }
    }
}