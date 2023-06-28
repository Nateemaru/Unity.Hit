using _Scripts.UI.UIInfrastructure.BaseComponents;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.UIInfrastructure.Views
{
    public class LevelProgressView : BaseView<LevelProgressController>
    {
        [SerializeField] private Image _fillImage;
        [SerializeField] private float _animationDuration;
        [SerializeField] private TMP_Text _textLevelCounter;
        private float _maxValue = 1f;
        
        [Inject]
        private void Construct(LevelProgressController controller)
        {
            Bind(controller);
        }
        
        protected override void OnBound()
        {
            _viewController.OnLevelProgressChanged += ChangeFill;
            _viewController.OnLevelCounterChanged += s => _textLevelCounter.text = $"Level {s}";
        }

        private void ChangeFill()
        {
            _fillImage.DOFillAmount(_viewController.GetLevelCompletePercent(_maxValue), _animationDuration);
        }
    }
}