using _Scripts.Gameplay;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthComponent _health;
        [SerializeField] private Image _mainImage;
        [SerializeField] private TMP_Text _text;
        
        [SerializeField] private bool _isGradient;
        [ShowIf("_isGradient")][SerializeField] private Gradient _gradient;
        
        [SerializeField] private bool _isAnimated;
        [ShowIf("_isAnimated")][SerializeField] private Image _backgroundImage;
        [ShowIf("_isAnimated")][SerializeField] private float _animationDuration;

        private void Start()
        {
            _health.OnDeadAction += () => gameObject.SetActive(false);
            _health.OnHealthChanged += UpdateHealthBar;
            UpdateHealthBar();
        }

        private void OnDisable()
        {
            if (_backgroundImage != null)
                _backgroundImage.DOKill(true);
        }

        private void UpdateHealthBar()
        {
            _mainImage.fillAmount = _health.CurrentHp / _health.MaxHp;
            _text.text = _health.CurrentHp.ToString();
            
            if(_isGradient)
                _mainImage.color = _gradient.Evaluate(_health.CurrentHp / _health.MaxHp);
            
            if(_isAnimated)
                AnimateBar();
        }

        private void AnimateBar()
        {
            _backgroundImage.DOKill();
            _backgroundImage.DOFillAmount(_mainImage.fillAmount, _animationDuration);
        }
    }
}