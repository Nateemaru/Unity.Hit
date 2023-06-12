using System;
using _Scripts.Services;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Camera
{ 
    public class CameraTargetController : MonoBehaviour
    {
        [SerializeField] private CinemachineTargetGroup[] _targetGroup;
        [SerializeField] private CinemachineVirtualCamera _mainVCam;

        private int _groupCount = 1;
        
        
        [Button]
        private void ChangeTargetGroup()
        {
            if(_groupCount < _targetGroup.Length)
                _mainVCam.LookAt = _targetGroup[_groupCount++].transform;
        }
    }
}