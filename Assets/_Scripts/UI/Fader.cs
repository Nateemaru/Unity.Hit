using System;
using System.Threading.Tasks;
using _Scripts.CodeSugar;
using Animancer;
using UnityEngine;

namespace _Scripts.UI
{
    [RequireComponent(typeof(AnimancerComponent))]
    public class Fader : MonoBehaviour, IFadeScreen
    {
        [SerializeField] private AnimationClip _fadeInClip;
        [SerializeField] private AnimationClip _fadeOutClip;
        
        private AnimancerComponent _animancer;
        private bool _isFading = false;

        private void OnEnable()
        {
            if(_animancer == null)
                _animancer = GetComponent<AnimancerComponent>();
        }

        public void FadeIn(Action onFadedIn = null)
        {
            if (!_isFading)
            {
                _isFading = true;
                gameObject.Enable();
                AnimancerState animancerState = _animancer.Play(_fadeInClip);
                animancerState.Events.Add(1, () =>
                {
                    onFadedIn?.Invoke();
                    _isFading = false;
                });
            }
        }

        public void FadeOut(Action onFadedOut = null)
        {
            _isFading = true;
            gameObject.Enable();
            AnimancerState animancerState = _animancer.Play(_fadeOutClip);
            animancerState.Events.Add(1, () =>
            {
                onFadedOut?.Invoke();
                _isFading = false;
                gameObject.SetActive(false);
            });
        }
    }
}