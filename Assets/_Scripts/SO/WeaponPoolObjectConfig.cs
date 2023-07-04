using System;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(menuName = "SO/WeaponPoolObjectConfig", fileName = "Weapon Pool Object Config")]
    [Serializable]
    public class WeaponPoolObjectConfig : PoolObjectConfig
    {
        [SerializeField] private Sprite _sprite;

        public Sprite Sprite => _sprite;
    }
}