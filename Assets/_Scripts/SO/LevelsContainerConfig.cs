using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "LevelsContainerConfig", menuName = "SO/Levels Container Config")]
    public class LevelsContainerConfig : ScriptableObject
    {
        [SerializeField] private GameObject[] _levelPrefabs;

        public GameObject[] LevelPrefabs => _levelPrefabs;
    }
}