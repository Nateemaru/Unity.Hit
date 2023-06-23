using _Scripts.UI.UIInfrastructure.BaseComponents;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.UIInfrastructure
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