using UnityEngine;

namespace _Scripts.UI.UIInfrastructure.BaseComponents
{
    public abstract class BaseView<TViewController> : MonoBehaviour, IView where TViewController : class, IViewController
    {
        protected TViewController _viewController;

        protected abstract void OnBound();
        
        public void Bind(TViewController viewModel)
        {
            _viewController = viewModel;
            OnBound();
        }
    }
}