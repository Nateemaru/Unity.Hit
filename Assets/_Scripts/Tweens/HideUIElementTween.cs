using System;
using _Scripts.Services.StateMachines;
using _Scripts.Services.StateMachines.LevelStateMachine;
using _Scripts.Services.StateMachines.LevelStateMachine.LevelStates;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace _Scripts.Tweens
{
    [Serializable]
    enum HideDirection
    {
        Right,
        Left
    }
    
    [RequireComponent(typeof(RectTransform))]
    public class HideUIElementTween : MonoBehaviour
    {
        [SerializeField] private HideDirection _hideDirection;
        [SerializeField] private float _hideDuration;
        private float _hideDistance = 0;
        private ILevelStateMachine _levelStateMachine;

        [Inject]
        private void Construct(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
            _levelStateMachine.OnStateChanged += HideButton;
        }

        private void Start()
        {
            var rect = GetComponent<RectTransform>();
            
            if (_hideDirection == HideDirection.Left)
                _hideDistance -= rect.sizeDelta.x;
            
            if(_hideDirection == HideDirection.Right)
                _hideDistance = rect.sizeDelta.x;
        }

        public void Play()
        {
            transform.DOMoveX(_hideDistance, _hideDuration).SetEase(Ease.Linear);
        }

        public void Kill()
        {
            transform.DOKill();
        }

        private void HideButton(IState levelState)
        {
            if (levelState.GetType() == typeof(LevelRunState))
            {
                Kill();
                Play();
            }
        }
    }
}