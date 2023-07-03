using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "SO/Unit Config")]
    public class UnitConfig : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;
        [SerializeField] private float _attackDistance;

        public int Damage => _damage;

        public float Speed => _speed;

        public float Hp => _hp;

        public float AttackDistance => _attackDistance;
    }
}