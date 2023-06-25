using System;
using _Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerRotate : MonoBehaviour
    {
        private CameraHasher _camerasHasher;

        [Inject]
        private void Construct(CameraHasher camerasHasher)
        {
            _camerasHasher = camerasHasher;
        }
        
        private void Update()
        {
            transform.rotation = _camerasHasher.ActiveCamera.transform.rotation;
        }
    }
}