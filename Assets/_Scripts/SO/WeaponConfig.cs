using System;
using _Scripts.Player;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(menuName = "SO/Weapon Config", fileName = "WeaponConfig")]
    [Serializable]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private WeaponMetaData _metaData;

        public GameObject Prefab => _prefab;
        public Sprite Sprite => _sprite;

        public WeaponMetaData MetaData => _metaData;
    }
}