using System;
using _Scripts.SO;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.UIInfrastructure.Views
{
    public class WeaponItemView : BaseView<WeaponItemsListController>
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        [Inject]
        private void Construct(WeaponItemsListController controller)
        {
            Bind(controller);
        }

        public void Init(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        protected override void OnBound()
        {
            _button.onClick.AddListener(() => _viewController.OnItemChosen(this));
        }
    }
}