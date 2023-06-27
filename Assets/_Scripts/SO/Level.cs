using System;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.SO
{
    [Serializable]
    public class Level
    {
        [SerializeField] private int _id;
        [JsonIgnore][SerializeField] private GameObject _prefab;

        [HideInInspector][SerializeField]private bool _isCompleted;

        public int ID => _id;
        [JsonIgnore] public GameObject Prefab => _prefab;

        public bool IsCompleted => _isCompleted;

        public void Complete() => _isCompleted = true;
    }
}