using _Scripts.CodeSugar;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.UIInfrastructure.Views
{
    public class SettingsScreenView : BaseView<SettingsScreenController>
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _openButton;
        [SerializeField] private Slider _volumeSlider;

        [Inject]
        private void Construct(SettingsScreenController controller)
        {
            Bind(controller);
        }

        protected override void OnBound()
        {
            _closeButton.onClick.AddListener(() =>
            {
                _viewController.OnCloseButtonClicked();
                Hide();
            });
            
            _openButton.onClick.AddListener(() =>
            {
                _viewController.OnOpenButtonClicked();
                Show();
            });
                
            _volumeSlider
                .onValueChanged
                .AddListener(delegate {_viewController
                    .OnSliderValueChanged(_volumeSlider.value);});
        }

        private void Show() => gameObject.Enable();
        private void Hide() => gameObject.Disable();
    }
}