using _Scripts.CodeSugar;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using Zenject;

namespace _Scripts.UI.UIInfrastructure.Views
{
    public class LoseScreenView : BaseView<LoseScreenController>
    {
        [Inject]
        private void Construct(LoseScreenController controller)
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