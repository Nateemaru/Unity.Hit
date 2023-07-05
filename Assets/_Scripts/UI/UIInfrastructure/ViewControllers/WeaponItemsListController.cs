using System.Collections.Generic;
using System.Linq;
using _Scripts.Factories;
using _Scripts.Services.Database;
using _Scripts.SO;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using _Scripts.UI.UIInfrastructure.Views;
using UnityEngine;

namespace _Scripts.UI.UIInfrastructure.ViewControllers
{
    public class WeaponItemsListController : BaseViewController
    {
        private WeaponItemView _prefab;
        private Transform _container;
        private readonly IDataReader _dataContainer;
        private readonly GameConfig _gameConfig;
        private readonly GameObjectFactory _factory;

        private Dictionary<WeaponItemView, WeaponConfig>
            _itemsDictionary = new Dictionary<WeaponItemView, WeaponConfig>();

        public WeaponItemsListController(IDataReader dataContainer, GameConfig gameConfig, GameObjectFactory factory)
        {
            _dataContainer = dataContainer;
            _gameConfig = gameConfig;
            _factory = factory;
        }

        public void FillStoreItemsList(WeaponItemView prefab, Transform container)
        {
            _prefab = prefab;
            _container = container;
            
            var weaponsDataFromJson =
                _dataContainer.GetArrayData<WeaponMetaData>(GlobalConstants.WEAPON_DATA_CONTAINER_KEY);

            for (int i = 0; i < weaponsDataFromJson.Length; i++)
            {
                var weaponConfig = _gameConfig
                    .WeaponSkinContainer.WeaponConfigs
                    .FirstOrDefault(item => item.MetaData.Name == weaponsDataFromJson[i].Name);
                var createdItem = _factory.CreateGameObject(_prefab.gameObject, _container);

                createdItem.GetComponent<WeaponItemView>().Init(weaponConfig.Sprite);
                _itemsDictionary.Add(createdItem.GetComponent<WeaponItemView>(), weaponConfig);
            }
        }

        public void OnItemChosen(WeaponItemView context)
        {
            var attachedWeaponConfig =
                _itemsDictionary.FirstOrDefault(item => item.Key == context).Value;

            _dataContainer.SaveData(GlobalConstants.CURRENT_WEAPON_DATA_KEY, attachedWeaponConfig.MetaData);
        }
    }
}