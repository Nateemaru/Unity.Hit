using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "SO/Projectile Config")]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        public float Speed => _speed;
        public float RotationSpeed => _rotationSpeed;
    }
}