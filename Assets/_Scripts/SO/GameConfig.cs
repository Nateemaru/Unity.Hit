using _Scripts.Player;
using Animancer.Examples.StateMachines.Weapons;
using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "SO/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private WeaponConfig _defaultWeapon;
        [SerializeField] private LevelsContainerConfig _levelsContainerConfig;
        [SerializeField] private WeaponConfigsContainer _weaponSkinContainer;

        public WeaponConfig DefaultWeapon => _defaultWeapon;

        public LevelsContainerConfig LevelsContainerConfig => _levelsContainerConfig;

        public WeaponConfigsContainer WeaponSkinContainer => _weaponSkinContainer;
    }
}