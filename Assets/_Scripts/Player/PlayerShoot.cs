

using System;
using System.Linq;
using _Scripts.Services;
using _Scripts.Services.Database;
using _Scripts.SO;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        private GameObject _weapon;
        [SerializeField] private Transform _hand;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private LayerMask _targetMask;
        private IDataReader _dataReader;
        private GameConfig _gameConfig;

        [Inject]
        private void Construct(IDataReader dataReader, GameConfig gameConfig)
        {
            _dataReader = dataReader;
            _gameConfig = gameConfig;
        }

        private void Start()
        {
            var weaponMetaData = _dataReader.GetData<WeaponMetaData>(GlobalConstants.CURRENT_WEAPON_DATA_KEY);
            _weapon = _gameConfig.WeaponSkinContainer.WeaponConfigs.FirstOrDefault(item =>
                item.MetaData.Name == weaponMetaData.Name)?.Prefab;
            Instantiate(_weapon.transform?.GetChild(0), _hand);
        }

        public void Shoot(Vector3 position)
        {
            var ray = Camera.main.ScreenPointToRay(position);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _targetMask))
            {
                var obj = PoolHub.Instance.GetObject(_weapon);
                        
                obj.transform.localPosition = _firePoint.position;
                obj.transform.LookAt(hit.point, Vector3.up);
                if(obj.TryGetComponent(out Bullet bullet))
                    bullet.SetDirection(hit.point);
            }
        }
    }
}