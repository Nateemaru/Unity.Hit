using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "WeaponSkinContainerConfig", menuName = "SO/Weapon Skin Container Config")]
    public class WeaponSkinContainer : ScriptableObject
    {
        [SerializeField] private PoolObjectConfig[] _weaponConfigs;

        public PoolObjectConfig[] WeaponConfigs => _weaponConfigs;
    }
}