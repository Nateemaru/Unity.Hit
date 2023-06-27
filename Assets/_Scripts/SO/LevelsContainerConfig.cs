using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "LevelsContainerConfig", menuName = "SO/Levels Container Config")]
    public class LevelsContainerConfig : ScriptableObject
    {
        [SerializeField] private Level[] _levels;

        public Level[] Levels => _levels;
    }
}