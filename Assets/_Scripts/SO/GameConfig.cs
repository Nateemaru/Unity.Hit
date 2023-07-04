using Animancer.Examples.StateMachines.Weapons;
using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "SO/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private PoolObjectConfig _defaultWeapon;
        [SerializeField] private LevelsContainerConfig _levelsContainerConfig;
        [SerializeField] private WeaponSkinContainer _weaponSkinContainer;

        public PoolObjectConfig DefaultWeapon => _defaultWeapon;

        public LevelsContainerConfig LevelsContainerConfig => _levelsContainerConfig;

        public WeaponSkinContainer WeaponSkinContainer => _weaponSkinContainer;
    }
}