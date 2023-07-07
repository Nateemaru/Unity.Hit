using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.CodeSugar;
using _Scripts.Factories;
using _Scripts.Services.Database;
using _Scripts.SO;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using _Scripts.UI.UIInfrastructure.ViewControllers;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.UIInfrastructure.Views
{
    public class WeaponItemsListView : BaseView<WeaponItemsListController>
    {
        [SerializeField] private Button _openStoreButton;
        [SerializeField] private Button _closeStoreButton;
        [SerializeField] private WeaponItemView _itemPrefab;
        [SerializeField] private Transform _itemsContainer;

        [Inject]
        private void Construct(WeaponItemsListController controller)
        {
            Bind(controller);
        }

        protected override void OnBound()
        {
            _viewController.FillStoreItemsList(_itemPrefab, _itemsContainer);
            _openStoreButton.onClick.AddListener(Show);
            _closeStoreButton.onClick.AddListener(Hide);
        }

        private void Show() => gameObject.Enable();
        private void Hide() => gameObject.Disable();
    }
}