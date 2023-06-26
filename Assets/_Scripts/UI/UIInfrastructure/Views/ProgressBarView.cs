using System;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.UIInfrastructure.Views
{
    public class ProgressBarView : BaseView<ProgressBarController>
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _text;

        [Inject]
        private void Construct(ProgressBarController progressBarController)
        {
            Bind(progressBarController);
        }

        protected override void OnBound()
        {
            _viewController.OnProgressBarUpdated += UpdateProgressBar;
            _viewController.OnFilled = () => _slider.value >= _slider.maxValue;
        }

        private void UpdateProgressBar(float value)
        {
            _slider.value += Mathf.Lerp(_slider.minValue, _slider.maxValue, value);
            _text.text = $"{Mathf.RoundToInt(_slider.value * 100)}%";
        }
    }
}