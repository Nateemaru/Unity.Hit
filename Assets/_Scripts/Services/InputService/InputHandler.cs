using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.Services.InputService
{ 
    public class InputHandler : MonoBehaviour, IInputService
    {
        public Action<Vector3> OnTouched { get; set; }

        private bool _isMobile;

        private void Start()
        {
            if (Application.isMobilePlatform)
                _isMobile = true;
        }

        private void OnDisable()
        {
            OnTouched = null;
        }

        private void Update()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (_isMobile)
                    ReadScreenTouches();
                else
                    ReadMouseButton();
            }
        }
        
        public void Reset()
        {
            OnTouched = null;
        }

        private void ReadMouseButton()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnTouched?.Invoke(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
            }
            else if (Input.GetMouseButtonUp(0))
            {
            }
        }

        private void ReadScreenTouches()
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);

                    switch (touch.phase)
                    {
                        case TouchPhase.Began: 
                            OnTouched?.Invoke(Input.GetTouch(i).position);
                            break;
                        case TouchPhase.Moved:
                            break;
                        case TouchPhase.Ended:
                            break;
                        case TouchPhase.Canceled:
                            break;
                    }
                }
            }
        }
    }
}