using System;
using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "LevelsContainerConfig", menuName = "SO/Levels Container Config")]
    public class LevelsContainerConfig : ScriptableObject
    {
        [SerializeField] private Level[] _levels;

        public Level[] Levels => _levels;

        [Serializable]
        public class Level
        {
            [SerializeField] private int _id;
            [SerializeField] private GameObject _prefab;

            public int ID => _id;
            public GameObject Prefab => _prefab;
        }
    }
}