using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "PoolObjectConfig", menuName = "SO/Pool Object Config")]
    public class PoolObjectConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private GameObject _prefab;
        
        public string Name => _name;
        public GameObject Prefab => _prefab;
    }
}