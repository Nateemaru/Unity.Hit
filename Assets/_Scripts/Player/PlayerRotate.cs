using System;
using _Scripts.Services.InputService;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private float _sensetivity;
        [SerializeField] private float _minRotX;
        [SerializeField] private float _maxRotX;
        [SerializeField] private float _minRotY;
        [SerializeField] private float _maxRotY;
        
        private float _xRotation;
        private float _yRotation;
        private Quaternion _originRotation;

        private bool _isRotating;

        public bool IsRotating => _isRotating;

        private void Start()
        {
            _originRotation = transform.rotation;
        }

        private void Update()
        {
            var mouseX = 0f;
            var mouseY = 0f;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                mouseX = Input.GetTouch(0).deltaPosition.x;
                mouseY = Input.GetTouch(0).deltaPosition.y;
                
                _xRotation += mouseX * _sensetivity * Time.deltaTime;
                _xRotation = Mathf.Clamp(_xRotation, _minRotX, _maxRotX);
                var rotY = Quaternion.AngleAxis(_xRotation, Vector3.up);
        
                _yRotation += mouseY * _sensetivity * Time.deltaTime;
                _yRotation = Mathf.Clamp(_yRotation, _minRotY, _maxRotY);
                var rotX = Quaternion.AngleAxis(-_yRotation, Vector3.right);

                transform.rotation = Quaternion.Lerp(transform.rotation, _originRotation * rotY * rotX, 5);

                _isRotating = true;
                return;
            }

            _isRotating = false;
        }
    }
}