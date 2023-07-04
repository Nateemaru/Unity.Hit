using System;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "PoolObjectConfig", menuName = "SO/Pool Object Config")]
    [Serializable]
    public class PoolObjectConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private GameObject _prefab;
        
        public string Name => _name;
        public GameObject Prefab => _prefab;
    }
}