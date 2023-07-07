using _Scripts.Player;
using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "WeaponSkinContainerConfig", menuName = "SO/Weapon Skin Container Config")]
    public class WeaponConfigsContainer : ScriptableObject
    {
        [SerializeField] private WeaponConfig[] _weaponConfigs;

        public WeaponConfig[] WeaponConfigs => _weaponConfigs;
    }
}