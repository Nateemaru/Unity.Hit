using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "VfxConfig", menuName = "SO/Vfx Config")]
    public class VfxConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private GameObject _prefab;
        
        public string Name => _name;
        public GameObject Prefab => _prefab;
    }
}