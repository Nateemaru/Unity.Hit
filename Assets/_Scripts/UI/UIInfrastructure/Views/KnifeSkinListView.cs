using _Scripts.UI.UIInfrastructure.BaseComponents;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.UIInfrastructure.Views
{
    public class KnifeSkinListView : BaseView<KnifeSkinListController>
    {
        [SerializeField] private Transform _itemContainer;
        
        [Inject]
        private void Construct(KnifeSkinListController controller)
        {
            Bind(controller);
        }

        protected override void OnBound()
        {
        }
    }
}