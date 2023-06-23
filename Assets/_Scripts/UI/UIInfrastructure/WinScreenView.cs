using _Scripts.CodeSugar;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.UIInfrastructure
{
    public class WinScreenView : BaseView<WinScreenController>
    {
        [Inject]
        private void Construct(WinScreenController controller)
        {
            Bind(controller);
        }
        
        protected override void OnBound()
        {
            _viewController.ShowCommand += Show;
        }

        private void Show() => gameObject.Enable();
        private void Hide() => gameObject.Disable();
    }
}