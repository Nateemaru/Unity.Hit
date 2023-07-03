using _Scripts.UI.UIInfrastructure.BaseComponents;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.UIInfrastructure.Views
{
    public class LoadSceneButtonView : BaseView<LoadSceneButtonController>
    {
        [SerializeField] private Button _loadSceneButton;
        
        [Inject]
        private void Construct(LoadSceneButtonController controller)
        {
            Bind(controller);
        }
        
        protected override void OnBound()
        {
            _loadSceneButton.onClick.AddListener(_viewController.OnButtonClicked);
        }
    }
}